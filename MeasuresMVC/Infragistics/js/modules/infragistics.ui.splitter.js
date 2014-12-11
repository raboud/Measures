﻿/*!@license
 * Infragistics.Web.ClientUI Splitter 13.2.20132.2157
 *
 * Copyright (c) 2011-2014 Infragistics Inc.
 *
 * http://www.infragistics.com/
 *
 * Depends on:
 *  jquery-1.4.4.js
 *	infragistics.util.js
 *	infragistics.ui.splitter-en.js
 */
if(typeof jQuery!=="function"){throw new Error("jQuery is undefined")}(function($){$.widget("ui.igSplitter",{_const:{orientations:{horizontal:{size:"height",oppositeSize:"width",outerSize:"outerHeight",dimention:"top",start:"_startY",mouse:"_mouseStartY",page:"pageY",keyboard:["UP","DOWN"]},vertical:{size:"width",oppositeSize:"height",outerSize:"outerWidth",dimention:"left",start:"_startX",mouse:"_mouseStartX",page:"pageX",keyboard:["LEFT","RIGHT"]}},properties:["max","_max","min","_min","size","collapsed","collapsible","resizable"],step:10,touchEvents:{mousedown:"touchstart",mouseup:"touchend",mousemove:"touchmove",mouseenter:"",mouseleave:"",focus:"focus",blur:"blur",keydown:"keydown"}},css:{splitter:"ui-igsplitter ui-widget ui-widget-content",verticalPanel:"ui-igsplitter-panel-vertical ui-widget-content",horizontalPanel:"ui-igsplitter-panel-horizontal ui-widget-content",bar:"ui-igsplitter-splitbar",barNormal:"ui-igsplitter-splitbar-default ui-state-default",barCollapsed:"ui-igsplitter-splitbar-collapsed",barHover:"ui-igsplitter-splitbar-hover ui-state-hover",barActive:"ui-igsplitter-splitbar-focus ui-state-focus",barInvalid:"ui-igsplitter-splitbar-invalid",resizeHandler:"ui-igsplitter-splitbar-resize-handler",resizeHandlerInner:"ui-igsplitter-splitbar-resize-handler-inner",verticalCollapseButtonLeftExpanded:"ui-igsplitter-collapse-button-vertical-left",verticalCollapseButtonLeftExpandedIcon:"ui-icon ui-icon-triangle-1-w",verticalCollapseButtonLeftCollapsed:"ui-igsplitter-collapse-button-vertical-left",verticalCollapseButtonLeftCollapsedIcon:"ui-icon ui-icon-triangle-1-e",verticalCollapseButtonRightExpanded:"ui-igsplitter-collapse-button-vertical-right",verticalCollapseButtonRightExpandedIcon:"ui-icon ui-icon-triangle-1-e",verticalCollapseButtonRightCollapsed:"ui-igsplitter-collapse-button-vertical-right",verticalCollapseButtonRightCollapsedIcon:"ui-icon ui-icon-triangle-1-w",horizontalCollapseButtonLeftExpanded:"ui-igsplitter-collapse-button-horizontal-left",horizontalCollapseButtonLeftExpandedIcon:"ui-icon ui-icon-triangle-1-n",horizontalCollapseButtonLeftCollapsed:"ui-igsplitter-collapse-button-horizontal-left",horizontalCollapseButtonLeftCollapsedIcon:"ui-icon ui-icon-triangle-1-s",horizontalCollapseButtonRightExpanded:"ui-igsplitter-collapse-button-horizontal-right",horizontalCollapseButtonRightExpandedIcon:"ui-icon ui-icon-triangle-1-s",horizontalCollapseButtonRightCollapsed:"ui-igsplitter-collapse-button-horizontal-right",horizontalCollapseButtonRightCollapsedIcon:"ui-icon ui-icon-triangle-1-n",collapseButtonDefault:"ui-state-default",collapseButtonSingle:"ui-igsplitter-collapse-single-button",collapseButtonPressed:"ui-igsplitter-collapse-button-pressed",collapseButtonHover:"ui-igsplitter-collapse-button-hover ui-state-hover",noScroll:"ui-igsplitter-no-scroll"},events:{collapsed:"collapsed",expanded:"expanded",resizeStarted:"resizeStarted",resizing:"resizing",resizeEnded:"resizeEnded",layoutRefreshing:"layoutRefreshing",layoutRefreshed:"layoutRefreshed"},options:{width:null,height:null,orientation:"vertical",panels:[],dragDelta:3},_opt:null,widget:function(){return this.element},_createWidget:function(options,element){this._opt={eventHandlers:{}};$.Widget.prototype._createWidget.apply(this,arguments)},_create:function(){var splitters,length=$(this.element.children("div")).length;this._htmlMarkup=this.element.html();if(this.options.panels.length>2||length>2){throw new Error($.ig.Splitter.locale.errorPanels)}if(length===1){$(this.element).append("<div/>")}else if(length===0){$(this.element).append("<div/>");$(this.element).append("<div/>")}this._panels=[];this._splitter={};splitters=$.data(document.body,"ig-splitters")||[];splitters.push(this.element);$.data(document.body,"ig-splitters",splitters);if(this.options.width){this.element.css("width",this.options.width)}if(this.options.height){this.element.css("height",this.options.height)}this._render();this._removeClasses();this._addClasses();this._removeEventHandlers();this._addEventHandlers();this._panelsLayout()},_setOption:function(option,value){var oldWidth,oldHeight;if(this.options[option]===value){return}$.Widget.prototype._setOption.apply(this,arguments);switch(option){case"width":oldWidth=this.element.width();this.element.css("width",value);if(this.options.orientation==="vertical"){this._setPanelsNewWidth(value,oldWidth)}this._panelsLayout();break;case"height":oldHeight=this.element.height();this.element.css("height",value);if(this.options.orientation==="horizontal"){this._setPanelsNewHeight(value,oldHeight)}this._panelsLayout();break;default:break}},_setPanelsNewWidth:function(newWidth,oldWidth){var secondPanelRatio=this.secondPanel().width()/oldWidth;this.setSecondPanelSize(newWidth*secondPanelRatio)},_setPanelsNewHeight:function(newHeight,oldHeight){var secondPanelRatio=this.secondPanel().height()/oldHeight;this.setSecondPanelSize(newHeight*secondPanelRatio)},_render:function(){var panels=$(this.element.children("div")),panel,self=this,reducedSize,defaultSize=0,j;reducedSize=this._reducedSize();if(this.options[this._getOrientation("size")]){defaultSize=this.options[this._getOrientation("size")]-reducedSize.size}else{defaultSize=this._getSize(this._getOrientation("size"))-reducedSize.size}if(panels.length-reducedSize.length!==0){defaultSize=Math.floor(defaultSize/(panels.length-reducedSize.length))}if(this._panels.length<1){panels.each(function(i,element){panel=$(element);panel.options={max:9007199254740992,_max:"100%",min:0,_min:"0",collapsible:false,resizable:true,collapsed:false,size:panel[self._getOrientation("size")]()};for(j=0;j<self._const.properties.length;j++){if(self.options.panels[i]&&self.options.panels[i][self._const.properties[j]]!==undefined&&self.options.panels[i][self._const.properties[j]]!==null){panel.options[self._const.properties[j]]=self.options.panels[i][self._const.properties[j]]}else{if(self._const.properties[j]==="size"){if(panel[0].style[self._getOrientation("size")]!=="auto"&&panel[0].style[self._getOrientation("size")]!==""){panel.options.size=panel[self._getOrientation("size")]()}else{panel.options.size=defaultSize}}}}self._panels.push(panel)});this._createSplitter()}},_reducedSize:function(){var i,reducedSize={size:0,length:0},size=0;for(i=0;i<this.options.panels.length;i++){size=0;if(this.options.panels[i].size!==undefined){if(/%/.test(this.options.panels[i].size)){this.options.panels[i].size=this.options.panels[i].size.replace("%","")*this._getSize(this._getOrientation("size"))/100;this._isPercentLayout=true}if(/px/.test(this.options.panels[i].size)){this.options.panels[i].size=parseInt(this.options.panels[i].size,10)}if(/px/.test(this.options.panels[i].min)){this.options.panels[i].min=parseInt(this.options.panels[i].min,10)}if(/%/.test(this.options.panels[i].min)){this.options.panels[i]._min=this.options.panels[i].min;this.options.panels[i].min=this.options.panels[i].min.replace("%","")*this._getSize(this._getOrientation("size"))/100}if(/px/.test(this.options.panels[i].max)){this.options.panels[i].max=parseInt(this.options.panels[i].max,10)}if(/%/.test(this.options.panels[i].max)){this.options.panels[i]._max=this.options.panels[i].max;this.options.panels[i].max=this.options.panels[i].max.replace("%","")*this._getSize(this._getOrientation("size"))/100}size=this.options.panels[i].size;reducedSize.length+=1}reducedSize.size+=size}return reducedSize},_getSize:function(size){var boxSizing=this.element.css("box-sizing"),value;if(window.getComputedStyle!==undefined){value=parseInt(window.getComputedStyle(this.element[0])[size],10);if($.ig.util.isChrome&&boxSizing==="border-box"){value-=parseInt(this.element.css("border-width"),10)*2}return value}return this.element[size]()},_getOrientation:function(property){return this._const.orientations[this.options.orientation][property]},_getEvent:function(event){if(this._isTouch()){return this._const.touchEvents[event]}return event},_isTouch:function(){var isTouch=typeof window.Modernizr==="object"&&window.Modernizr.touch===true;return isTouch},_createSplitter:function(){var collapseButtons=$("<div><span></span></div><div><span></span></div>"),bar=$("<div></div>").attr("tabindex",0),div;this._splitter={left:this._panels[0],right:this._panels[1]};bar.insertAfter(this._panels[0]);this._splitter.bar=bar;this._splitter.bar.append(collapseButtons);div=$("<div/>").appendTo(this._splitter.bar);$("<span></span>")[this._getOrientation("size")](this._splitter.bar[this._getOrientation("size")]).attr("title","").appendTo(div)},_removeClasses:function(){var buttonLeft,buttonRight,resizeHandler,i;this.element.removeClass(this.css.splitter);for(i=0;i<this._panels.length;i++){this._panels[i].removeClass(this.css[this.options.orientation+"Panel"])}this._splitter.bar.removeClass(this.css.bar+"-"+this.options.orientation);this._splitter.bar.removeClass(this.css.barNormal);this._splitter.bar.removeClass(this.css.barCollapsed);buttonLeft=$(this._splitter.bar.children()[0]);buttonRight=$(this._splitter.bar.children()[1]);buttonLeft.removeClass(this.css[this.options.orientation+"CollapseButtonLeftExpanded"]);buttonRight.removeClass(this.css[this.options.orientation+"CollapseButtonRightExpanded"]);buttonLeft.removeClass(this.css.collapseButtonDefault);buttonRight.removeClass(this.css.collapseButtonDefault);resizeHandler=$(this._splitter.bar.children()[2]);resizeHandler.removeClass(this.css.resizeHandler+"-"+this.options.orientation);$(resizeHandler.children()[0]).removeClass(this.css.resizeHandlerInner+"-"+this.options.orientation)},_addClasses:function(){var buttonLeft,buttonRight,i,resizeHandler;this.element.addClass(this.css.splitter);for(i=0;i<this._panels.length;i++){this._panels[i].addClass(this.css[this.options.orientation+"Panel"])}this._splitter.bar.addClass(this.css.bar+"-"+this.options.orientation);this._splitter.bar.addClass(this.css.barNormal);if(this._panels[0].options.collapsed||this._panels[1].options.collapsed){this._splitter.bar.addClass(this.css.barCollapsed)}buttonLeft=$(this._splitter.bar.children()[0]);buttonRight=$(this._splitter.bar.children()[1]);buttonLeft.addClass(this.css[this.options.orientation+"CollapseButtonLeftExpanded"]);$(buttonLeft.children()).addClass(this.css[this.options.orientation+"CollapseButtonLeftExpandedIcon"]);buttonRight.addClass(this.css[this.options.orientation+"CollapseButtonRightExpanded"]);$(buttonRight.children()).addClass(this.css[this.options.orientation+"CollapseButtonRightExpandedIcon"]);resizeHandler=$(this._splitter.bar.children()[2]);resizeHandler.addClass(this.css.resizeHandler+"-"+this.options.orientation);$(resizeHandler.children()[0]).addClass(this.css.resizeHandlerInner+"-"+this.options.orientation);if(!this._panels[0].options.collapsible){buttonLeft.hide();buttonRight.addClass(this.css.collapseButtonSingle)}if(!this._panels[1].options.collapsible){buttonRight.hide();buttonLeft.addClass(this.css.collapseButtonSingle)}buttonLeft.addClass(this.css.collapseButtonDefault);buttonRight.addClass(this.css.collapseButtonDefault)},_removeEventHandlers:function(){$(this._splitter.bar).unbind(this._getEvent("focus"),this._getEvent("blur"),this._getEvent("keydown"));$(this._splitter.bar.children()[0]).unbind(this._getEvent("mousedown"));$(this._splitter.bar.children()[1]).unbind(this._getEvent("mousedown"));if(!this._isTouch()){$(this._splitter.bar).unbind(this._getEvent("mouseenter"),this._getEvent("mouseleave"));$(this._splitter.bar.children()[0]).unbind(this._getEvent("mouseenter"),this._getEvent("mouseleave"));$(this._splitter.bar.children()[1]).unbind(this._getEvent("mouseenter"),this._getEvent("mouseleave"))}},_addEventHandlers:function(){var self=this;self.autoResize=true;this._opt.eventHandlers.documentMouseUp=function(){self.autoResize=false;self._stopDrag(self);self.autoResize=true;self._lastMove=null};$(document).bind(this._getEvent("mouseup")+"."+this.element.attr("id"),this._opt.eventHandlers.documentMouseUp);this._opt.eventHandlers.documentMouseMove=function(ev){var noCancel=true;self._currentMove=self._isTouch()?ev.originalEvent.touches[0][self._getOrientation("page")]:ev[self._getOrientation("page")];if(self._capturedElement&&self._isDragging()&&!self._isDrag){self._triggerResizeStarted();self._isDrag=true}if(self._capturedElement&&self._isDragging()){noCancel=self._triggerResizing()}if(noCancel&&self._isDragging()){self._performDrag(self,ev)}else{return false}};$(document).bind(this._getEvent("mousemove")+"."+this.element.attr("id"),this._opt.eventHandlers.documentMouseMove);this._opt.eventHandlers.windowResize=function(ev){var noCancel=self._triggerLayoutRefreshing();if(noCancel){self._panelsLayout();self._triggerLayoutRefreshed()}};$(window).bind("resize."+this.element.attr("id"),this._opt.eventHandlers.windowResize);this._addBarHandlers(this._splitter);this._addCollapseButtonHandlers($(this._splitter.bar.children()[0]),0);this._addCollapseButtonHandlers($(this._splitter.bar.children()[1]),1)},_isDragging:function(){return Math.abs(this._currentMove-this._lastMove)>this.options.dragDelta},_addBarHandlers:function(splitter){var self=this;splitter.bar.bind(this._getEvent("mousedown"),{self:this},this._startDrag);$(splitter.bar.children()[2]).bind(this._getEvent("mousedown"),{self:this},this._startDrag);splitter.bar.bind(this._getEvent("keydown"),{self:this},this._kbNavigation);if(!this._isTouch()){splitter.bar.bind(this._getEvent("mouseenter"),function(){$(this).addClass(self.css.barHover)});splitter.bar.bind(this._getEvent("mouseleave"),function(){$(this).removeClass(self.css.barHover)})}splitter.bar.bind(this._getEvent("focus"),function(){$(this).addClass(self.css.barActive)});splitter.bar.bind(this._getEvent("blur"),function(){$(this).removeClass(self.css.barActive)})},_kbNavigation:function(event){var splitter=event.data.self,noCancel=true;if(event.keyCode===$.ui.keyCode[splitter._getOrientation("keyboard")[0]]){if(event.ctrlKey){splitter._stopDrag(splitter,true,true);if(splitter._panels[1].options.collapsed){splitter.expandAt(1)}else if(!splitter._panels[0].options.collapsed){splitter.collapseAt(0)}}else{splitter._startDrag(event);splitter._kbMove-=splitter._kbLockRight?0:splitter._getStep();if(splitter._capturedElement&&!splitter._isDrag){splitter._triggerResizeStarted();splitter._isDrag=true}if(splitter._capturedElement){noCancel=splitter._triggerResizing()}if(noCancel){splitter._performDrag(splitter,event)}else{return false}if(splitter._capturedElement&&splitter._capturedElement.hasClass(splitter.css.barInvalid)){splitter._kbLockRight=true;splitter._kbLockLeft=false}else{splitter._kbLockRight=false;splitter._kbLockLeft=false}}event.preventDefault()}else if(event.keyCode===$.ui.keyCode[splitter._getOrientation("keyboard")[1]]){if(event.ctrlKey){splitter._stopDrag(splitter,true,true);if(splitter._panels[0].options.collapsed){splitter.expandAt(0)}else if(!splitter._panels[1].options.collapsed){splitter.collapseAt(1)}}else{splitter._startDrag(event);splitter._kbMove+=splitter._kbLockLeft?0:splitter._getStep();if(splitter._capturedElement&&!splitter._isDrag){splitter._triggerResizeStarted();splitter._isDrag=true}if(splitter._capturedElement){noCancel=splitter._triggerResizing()}if(noCancel){splitter._performDrag(splitter,event)}else{return false}if(splitter._capturedElement&&splitter._capturedElement.hasClass(splitter.css.barInvalid)){splitter._kbLockRight=false;splitter._kbLockLeft=true}else{splitter._kbLockRight=false;splitter._kbLockLeft=false}}event.preventDefault()}else if(event.keyCode===$.ui.keyCode.ENTER||event.keyCode===$.ui.keyCode.SPACE){splitter._stopDrag(splitter,false,true);event.preventDefault()}else if(event.keyCode===$.ui.keyCode.ESCAPE){splitter._stopDrag(splitter,true)}else if(event.keyCode===$.ui.keyCode.TAB){splitter._stopDrag(splitter,false,true)}},_startDrag:function(event){var splitter=event.data.self,left,right;splitter._splitter.bar.focus();splitter._resizeArea=splitter._splitter;if(splitter._resizeArea!==null){if((splitter._resizeArea.left.options.resizable===undefined||splitter._resizeArea.left.options.resizable)&&(splitter._resizeArea.right.options.resizable===undefined||splitter._resizeArea.right.options.resizable)){left=splitter._resizeArea.left;right=splitter._resizeArea.right;if(!left.options.collapsed&&!right.options.collapsed&&!(right.options.max<=right[splitter._getOrientation("outerSize")]()&&left.options.max<=left[splitter._getOrientation("outerSize")]())){if(!splitter._capturedElement){splitter._lastMove=splitter._isTouch()?event.originalEvent.touches[0][splitter._getOrientation("page")]:event[splitter._getOrientation("page")];if($(event.target).is("span")){splitter._capturedElement=splitter._clone($($(event.target).parent()).parent())}else{splitter._capturedElement=splitter._clone(event.target)}splitter._capturedElement.offset();splitter._startX=splitter._capturedElement.offset().left;splitter._startY=splitter._capturedElement.offset().top;splitter._kbMove=0;splitter._kbLockLeft=false;splitter._kbLockRight=false;splitter._mouseStartX=splitter._isTouch()?event.originalEvent.touches[0].pageX:event.pageX;splitter._mouseStartY=splitter._isTouch()?event.originalEvent.touches[0].pageY:event.pageY}}}return false}return false},_clone:function(bar){var clonedBar=$(bar).clone();clonedBar.css({position:"absolute",top:$(bar).offset().top,left:$(bar).offset().left,"z-index":9999}).fadeTo(0,.7);$(document.body).append(clonedBar);return clonedBar},_addCollapseButtonHandlers:function(button,index){var self=this;button.bind(this._getEvent("mouseenter"),function(e){$($(this).parent()).removeClass(self.css.barHover);$(this).addClass(self.css.collapseButtonHover);if(e.stopPropagation!==undefined){e.stopPropagation()}if(e.preventDefault!==undefined){e.preventDefault()}return false});button.bind(this._getEvent("mouseleave"),function(e){$($(this).parent()).addClass(self.css.barHover);$(this).removeClass(self.css.collapseButtonHover)});button.bind("mousedown touchstart",function(e){$(this).toggleClass(self.css.collapseButtonPressed);if(self._panels[index].options.collapsed){self.expandAt(index)}else{self.collapseAt(index)}if(e.stopPropagation!==undefined){e.stopPropagation()}if(e.preventDefault!==undefined){e.preventDefault()}return false})},_performDrag:function(self,ev){var page=self._isTouch()?ev.originalEvent.touches[0][self._getOrientation("page")]:ev[self._getOrientation("page")],bar;if(ev.which===0&&$.ig.util.isIE&&$.ig.util.isIEOld){self._stopDrag(self);return false}if(self._capturedElement){if(ev.type==="keydown"){bar=self[self._getOrientation("start")]+self._kbMove}else{bar=page-self[self._getOrientation("mouse")]+self[self._getOrientation("start")]}self._moveBar(bar);return false}return true},_moveBar:function(bar){bar=this._validatePosition(bar);if(bar.invalid){this._capturedElement.addClass(this.css.barInvalid)}else{this._capturedElement.removeClass(this.css.barInvalid)}this._capturedElement.css(this._getOrientation("dimention"),bar.position)},_validatePosition:function(bar){var resizeArea=this._resizeArea,rightBoundary=this._getNextBoundary(resizeArea),getPreviousBoundary=this._getPreviousBoundary(resizeArea),min=Math.min(rightBoundary,rightBoundary-resizeArea.right.options.min,getPreviousBoundary+resizeArea.left.options.max),max=Math.max(getPreviousBoundary,getPreviousBoundary+resizeArea.left.options.min,rightBoundary-resizeArea.right.options.max),pos;if(max>min){pos=resizeArea.right.offset()[this._getOrientation("dimention")]-this._capturedElement[this._getOrientation("outerSize")](true);return{position:pos,invalid:true}}if(bar<max){return{position:max,invalid:true}}if(bar>min){return{position:min,invalid:true}}return{position:bar,invalid:false}},_getNextBoundary:function(panel){var size=panel.right.offset()[this._getOrientation("dimention")]+panel.right[this._getOrientation("size")]()-this._capturedElement[this._getOrientation("outerSize")](true);if(panel.right.options.collapsed){size-=panel.right.options.min}return size},_getPreviousBoundary:function(panel){var size=panel.left.offset()[this._getOrientation("dimention")];if(panel.left.options.collapsed){size+=panel.left.options.min}return size},_stopDrag:function(self,cancel,kbMove){if(self._capturedElement){if(!cancel&&(self._isDrag||kbMove)){self._performAreaResize()}self._capturedElement.remove();self._isDrag=false}self._capturedElement=null},_performAreaResize:function(){var resizeArea=this._resizeArea,offset=this._capturedElement.offset()[this._getOrientation("dimention")]-this[this._getOrientation("start")],left=resizeArea.left[this._getOrientation("size")]()+offset,right=resizeArea.right[this._getOrientation("size")]()-offset;this._setPanelSize(resizeArea.left,left);this._setPanelSize(resizeArea.right,right);if(offset!==0){this._triggerResizeEnded()}this._splittersLayout()},_splittersLayout:function(){var splitters=$.data(document.body,"ig-splitters")||[],i;for(i=0;i<splitters.length;i++){if(splitters[i][0]!==this.element){$(splitters[i]).data("igSplitter")._panelsLayout()}}},_panelsLayout:function(){var i,outerSize=(this._panels.length-1)*this._splitter.bar[this._getOrientation("outerSize")](true),size=this._getSize(this._getOrientation("size"));for(i=0;i<this._panels.length;i++){if(!this._panels[i].options.collapsed){outerSize+=this._handlerPanelSize(this._panels[i],outerSize,size)}else{this._handlerPanelSize(this._panels[i],outerSize,size);$(this._splitter.bar.children()[(i+1)%2]).hide();$(this._splitter.bar.children()[i]).removeClass(this.css[this.options.orientation+"CollapseButton"+(i%2===0?"Left":"Right")+"Expanded"]);$($(this._splitter.bar.children()[i]).children()).removeClass(this.css[this.options.orientation+"CollapseButton"+(i%2===0?"Left":"Right")+"ExpandedIcon"]);$(this._splitter.bar.children()[i]).addClass(this.css[this.options.orientation+"CollapseButton"+(i%2===0?"Left":"Right")+"Collapsed"]);$($(this._splitter.bar.children()[i]).children()).addClass(this.css[this.options.orientation+"CollapseButton"+(i%2===0?"Left":"Right")+"CollapsedIcon"])}}if(outerSize<size){this._createPanel(size,outerSize,this._panels.length-1)}this._splitter.bar[this._getOrientation("oppositeSize")](this.element[this._getOrientation("oppositeSize")]()-2);$(this._splitter.bar.children()[2]).find("span")[this._getOrientation("oppositeSize")](this.element[this._getOrientation("oppositeSize")]())},_getStep:function(){return this._const.step+this._splitter.bar[this._getOrientation("size")]()},_handlerPanelSize:function(panel,outerSize,size){if(this._isPercentLayout){if(panel.options._min!==undefined){panel.options.min=panel.options._min.replace("%","")*this._getSize(this._getOrientation("size"))/100}if(panel.options._max!==undefined){panel.options.max=panel.options._max.replace("%","")*this._getSize(this._getOrientation("size"))/100}}this._setPanelSize(panel,panel.options.size);var newSize;if(outerSize+panel.options.size>=size&&!panel.options.collapsed){newSize=size-outerSize;if(!panel.options.collapsed){if(this._isPercentLayout){panel[this._getOrientation("size")](newSize/this._getSize(this._getOrientation("size"))*100+"%")}else{panel[this._getOrientation("size")](newSize)}panel.options.size=newSize}}return panel[this._getOrientation("outerSize")](true)},_setPanelSize:function(panel,size){if(!panel.options.collapsed){panel.options.size=parseInt(size,10);if(panel.options.size===0||this._isPercentLayout&&panel.options.size<=$.ig.util.getScrollWidth()){panel.addClass(this.css.noScroll)}else{panel.removeClass(this.css.noScroll)}if(this._isPercentLayout){size=parseInt(size,10);panel[this._getOrientation("size")](size/this._getSize(this._getOrientation("size"))*100+"%")}else{panel[this._getOrientation("size")](size)}}else{panel.addClass(this.css.noScroll);panel[this._getOrientation("size")](0)}},_createPanel:function(size,outerSize,index){if(index===undefined){index=0}var panel=this._panels[index],newSize=size-outerSize,panelSize=panel[this._getOrientation("size")](),maxSize=newSize+panelSize;if(index<=this._panels.length){if(panel.options.collapsed){this._panelHelper(outerSize,size)}else{if(maxSize>panel.options.max){panel.options.max=maxSize}if(this._isPercentLayout){panel[this._getOrientation("size")](maxSize/this._getSize(this._getOrientation("size"))*100+"%")}else{panel[this._getOrientation("size")](maxSize)}panel.options.size=maxSize}return}maxSize=Math.min(maxSize,panel.options.max);if(!panel.options.collapsed){panel[this._getOrientation("size")](maxSize);panel.options.size=maxSize}else{maxSize=panelSize=0}if(maxSize+(outerSize-panelSize)<size||panel.options.collapsed){this._createPanel(size,outerSize-panelSize+maxSize,index-1)}},_panelHelper:function(outerSize,size){var panel,flag=false,i;for(i=0;i<this._panels.length&&!flag;i++){panel=this._panels[i];if(!panel.options.collapsed){flag=true}}panel[this._getOrientation("size")](size-outerSize+panel[this._getOrientation("size")]())},expandAt:function(index){var neighborPanel;if(index<=this._panels.length&&index>=0&&this._panels[index].options.collapsed){neighborPanel=this._panels[index%2===0?1:0];this._panels[index].options.collapsed=false;this._panels[index].options.size=Math.min(this._panels[index].options.size,neighborPanel[this._getOrientation("size")]());neighborPanel.options.size=neighborPanel[this._getOrientation("size")]()-this._panels[index].options.size;this._splitter.bar.removeClass(this.css.barCollapsed);if(this._panels[(index+1)%2].options.collapsible){$(this._splitter.bar.children()[(index+1)%2]).show()}$(this._splitter.bar.children()[index]).removeClass(this.css.collapseButtonPressed);$(this._splitter.bar.children()[index]).removeClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"Collapsed"]);$($(this._splitter.bar.children()[index]).children()).removeClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"CollapsedIcon"]);$(this._splitter.bar.children()[index]).addClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"Expanded"]);$($(this._splitter.bar.children()[index]).children()).addClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"ExpandedIcon"]);neighborPanel.css(this._getOrientation("size"),neighborPanel.options.size);this._panels[index].css(this._getOrientation("size"),this._panels[index].options.size);this._splittersLayout();this._triggerExpanded(index)}},collapseAt:function(index){var size,neighborPanel;if(index<this._panels.length&&index>=0&&!this._panels[index].options.collapsed&&this._panels[index].options.collapsible){size=this._panels[index][this._getOrientation("size")]();neighborPanel=this._panels[index%2===0?1:0];this._panels[index].options.size=size||this._panels[index].options.size;this._panels[index].options.collapsed=true;this._splitter.bar.addClass(this.css.barCollapsed);$(this._splitter.bar.children()[(index+1)%2]).hide();$(this._splitter.bar.children()[index]).addClass(this.css.collapseButtonPressed);$(this._splitter.bar.children()[index]).removeClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"Expanded"]);$($(this._splitter.bar.children()[index]).children()).removeClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"ExpandedIcon"]);$(this._splitter.bar.children()[index]).addClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"Collapsed"]);$($(this._splitter.bar.children()[index]).children()).addClass(this.css[this.options.orientation+"CollapseButton"+(index%2===0?"Left":"Right")+"CollapsedIcon"]);neighborPanel.options.size=neighborPanel[this._getOrientation("size")]()+size;neighborPanel.css(this._getOrientation("size"),neighborPanel.options.size);this._panels[index].css(this._getOrientation("size"),0);this._splittersLayout();this._triggerCollapsed(index)}},_animateResize:function(panel,size,animationDuration,callback){var properties={},self=this;properties[this._getOrientation("size")]=size;panel.animate(properties,{step:function(){self._splittersLayout()},duration:animationDuration,complete:function(){self._splittersLayout();if(callback&&typeof callback==="function"){callback()}}})},_triggerCollapsed:function(index){var args={owner:this,index:index};this._trigger(this.events.collapsed,null,args)},_triggerExpanded:function(index){var args={owner:this,index:index};this._trigger(this.events.expanded,null,args)},_triggerResizeStarted:function(){var args={owner:this};this._trigger(this.events.resizeStarted,null,args)},_triggerResizing:function(){var args={owner:this};return this._trigger(this.events.resizing,null,args)},_triggerResizeEnded:function(){var args={owner:this};this._trigger(this.events.resizeEnded,null,args)},_triggerLayoutRefreshing:function(){var args={owner:this};return this._trigger(this.events.layoutRefreshing,null,args)},_triggerLayoutRefreshed:function(){var args={owner:this};return this._trigger(this.events.layoutRefreshed,null,args)},firstPanel:function(){return this._panels[0]},secondPanel:function(){return this._panels[1]},refreshLayout:function(){this._panelsLayout()},setFirstPanelSize:function(size){if(/%/.test(size)){size=size.replace("%","")*this._getSize(this._getOrientation("size"))/100;this._isPercentLayout=true}if(/px/.test(size)){size=parseInt(size,10)}this._setPanelSize(this._panels[0],size);this._splittersLayout()},setSecondPanelSize:function(size){if(/%/.test(size)){size=size.replace("%","")*this._getSize(this._getOrientation("size"))/100;this._isPercentLayout=true}if(/px/.test(size)){size=parseInt(size,10)}this._setPanelSize(this._panels[0],this._getSize(this._getOrientation("size"))-size);this._splittersLayout()},destroy:function(){var evtHandlers=this._opt.eventHandlers,i,splitters,index;this._removeEventHandlers();this._removeClasses();this.element.empty();this.element.html(this._htmlMarkup);splitters=$.data(document.body,"ig-splitters")||[];for(i=0;i<splitters.length;i++){if(splitters[i][0].id===this.element[0].id){index=i;break}}splitters.splice(index,1);$.data(document.body,"ig-splitters",splitters);$(document).unbind(this._getEvent("mouseup"),evtHandlers.documentMouseUp);$(document).unbind(this._getEvent("mousemove"),evtHandlers.documentMouseMove);$(window).unbind("resize",evtHandlers.windowResize);$.Widget.prototype.destroy.apply(this,arguments);return this}});$.extend($.ui.igSplitter,{version:"13.2.20132.2157"})})(jQuery);(function($){$(document).ready(function(){var wm=$("#__ig_wm__").length>0?$("#__ig_wm__"):$('<div id="__ig_wm__"></div>').appendTo(document.body);wm.css({position:"fixed",bottom:0,right:0,zIndex:1e3})})})(jQuery);
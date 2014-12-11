﻿/*!@license
* Infragistics.Web.ClientUI igCombo KnockoutJS extension 13.2.20132.2157
*
* Copyright (c) 2012-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
* Depends on:
*	jquery-1.7.2.js
*	ig.util.js
*	ig.dataSource.js
*/
(function($){ko.bindingHandlers.igCombo={init:function(element,valueAccessor,allBindingsAccessor,viewModel,bindingContext){var combo=$(element),options=$.isEmptyObject(valueAccessor())?{}:$.extend({},valueAccessor()),enableTextChangedUpdate=options.enableTextChangedUpdate,enableSelectionChangedUpdate=options.enableSelectionChangedUpdate,isCascading=false,currentDataSource,i;if(valueAccessor().text!==undefined){options.text=ko.utils.unwrapObservable(valueAccessor().text)}if(options.dataSource!==undefined){currentDataSource=options.dataSource;options.dataSource=typeof currentDataSource==="string"?currentDataSource:ko.toJS(currentDataSource)}else if(options.cascadingDataSources!==undefined){currentDataSource=options.cascadingDataSources;options.cascadingDataSources=typeof currentDataSource==="string"?currentDataSource:ko.toJS(currentDataSource);isCascading=true}delete options.enableTextChangedUpdate;delete options.enableSelectionChangedUpdate;combo.igCombo(options);if(currentDataSource!==undefined&&typeof currentDataSource!=="string"){if(isCascading){ko.applyBindingsToNode($(element).data("igCombo").mainElem[0],{igComboCascading:{combo:element}},currentDataSource)}else{currentDataSource=ko.isObservable(currentDataSource)?currentDataSource():currentDataSource;for(i=0;i<currentDataSource.length;i++){ko.applyBindingsToNode($(element).data("igCombo").mainElem[0],{igComboItem:{combo:element,value:currentDataSource[i],index:i,textKey:options.textKey,valueKey:options.valueKey}},currentDataSource[i])}}}if(valueAccessor().text===undefined||!ko.isObservable(valueAccessor().text)){return}if(valueAccessor().text()===undefined){valueAccessor().text(combo.igCombo("text"))}if(enableTextChangedUpdate){ko.utils.registerEventHandler(element,"igcombotextchanged",function(evt,ui){if(ui.text!==ui.oldText){valueAccessor().text(ui.text)}})}if(enableSelectionChangedUpdate){ko.utils.registerEventHandler(element,"igcomboselectionchanged",function(evt,ui){var selectedText="",comboSeperator=ui.owner.element.igCombo("option","itemSeparator"),i;if(ui.items!==null){for(i=0;i<ui.items.length;i++){selectedText+=ui.items[i].text+comboSeperator}}selectedText=selectedText.substring(0,selectedText.length-comboSeperator.length);valueAccessor().text(selectedText)})}ko.utils.registerEventHandler($(element).data("igCombo").fieldElem,"blur",function(e){valueAccessor().text(e.target.value)})},update:function(element,valueAccessor,allBindingsAccessor,viewModel,bindingContext){var oldDataSource,oldDataSourceCount,comboCustom,cascChildCombo,combo=$(element),oldText=combo.igCombo("text"),newText=ko.utils.unwrapObservable(valueAccessor().text),newDataSource=valueAccessor().dataSource;if(newDataSource!==undefined&&typeof newDataSource!=="string"){newDataSource=ko.toJS(newDataSource);oldDataSource=combo.igCombo("option","dataSource");oldDataSourceCount=oldDataSource!==undefined&&oldDataSource!==null?oldDataSource.length:0;if(newDataSource.length!==oldDataSourceCount){combo.one("igcombodatabound",function(evt,ui){combo.igCombo("text",oldText).blur()});combo.igCombo("option","dataSource",newDataSource)}cascChildCombo=combo.data("igCombo")._cascFire;while(cascChildCombo!==undefined){if(cascChildCombo[0]!==undefined){cascChildCombo[0].fieldElem.blur();cascChildCombo=cascChildCombo[0]._cascFire}}}if(newText===undefined||newText===oldText){return}combo.igCombo("text",newText);comboCustom=combo.igCombo("option","allowCustomValue");if(!comboCustom&&newText!==""&&combo.igCombo("text")===""){valueAccessor().text("")}}};ko.bindingHandlers.igComboItem={update:function(element,valueAccessor,allBindingsAccessor,viewModel){var combo,index,dsItem,newItem,textKey=ko.utils.unwrapObservable(valueAccessor().textKey),valueKey=ko.utils.unwrapObservable(valueAccessor().valueKey),isChanged=false;if(valueKey===undefined&&textKey===undefined){return}combo=$(valueAccessor().combo);index=valueAccessor().index;dsItem=combo.igCombo("getDataSource").data()[index];newItem=ko.toJS(viewModel);if(valueKey!==undefined&&newItem[valueKey]!==undefined&&dsItem[valueKey]!==newItem[valueKey]){dsItem[valueKey]=newItem[valueKey];if(dsItem[valueKey+"_"]!==undefined){dsItem[valueKey+"_"]=newItem[valueKey]}isChanged=true}if(textKey!==undefined&&newItem[textKey]!==undefined&&dsItem[textKey]!==newItem[textKey]){dsItem[textKey]=newItem[textKey];if(dsItem[textKey+"_"]!==undefined){dsItem[textKey+"_"]=newItem[textKey]}isChanged=true}if(isChanged){combo.data("igCombo")._renderRow(index,true)}}};ko.bindingHandlers.igComboCascading={update:function(element,valueAccessor,allBindingsAccessor,viewModel){var combo=$(valueAccessor().combo),newCascadingDS=ko.toJS(viewModel),oldText=combo.igCombo("text");combo.igCombo("option","cascadingDataSources",newCascadingDS);combo.igCombo("text",oldText).data("igCombo").fieldElem.blur()}};ko.bindingHandlers.igComboVisible={update:function(element,valueAccessor,allBindingsAccessor,viewModel,bindingContext){var visible=valueAccessor(),combo=$(element);if(!ko.isObservable(visible)){return}combo.css("display",visible()?"inline-block":"none")}}})(jQuery);(function($){$(document).ready(function(){var wm=$("#__ig_wm__").length>0?$("#__ig_wm__"):$('<div id="__ig_wm__"></div>').appendTo(document.body);wm.css({position:"fixed",bottom:0,right:0,zIndex:1e3})})})(jQuery);
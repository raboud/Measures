﻿/*!@license
* Infragistics.Web.ClientUI igGrid KnockoutJS extension 13.2.20132.2157
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
* Depends on:
*	jquery-1.7.1.js
*	ig.util.js
*	ig.dataSource.js
*	ig.ui.grid.framework.js
*/
ko.bindingHandlers.igGrid={init:function(element,valueAccessor,allBindingsAccessor,viewModel,bindingContext){var grid=$(element),gridObj=grid.data("igGrid"),binding,options,key;if(grid.attr("data-create")!=="false"){binding=ko.utils.unwrapObservable(valueAccessor());options={};options.dataSource=new $.ig.KnockoutDataSource({dataSource:binding.dataSource});for(key in binding){if(binding.hasOwnProperty(key)&&key!=="dataSource"){options[key]=binding[key]}}}else{binding=options=gridObj.options}grid.igGridKnockoutBridge();if(grid.attr("data-create")!=="false"){grid.igGrid(options)}else{grid.igGridKnockoutBridge("rebindCells")}return{controlsDescendantBindings:true}},update:function(element,valueAccessor,allBindingsAccessor,viewModel,bindingContext){$(element).igGridKnockoutBridge("recordsUpdated",valueAccessor)}};ko.visitPropertiesOrArrayEntries=function(rootObject,visitorCallback){var i,propertyName;if(rootObject instanceof Array){for(i=0;i<rootObject.length;i++){visitorCallback(i)}}else{for(propertyName in rootObject){if(rootObject.hasOwnProperty(propertyName)){visitorCallback(propertyName)}}}};ko.bindingHandlers.igHierarchicalGrid={init:function(element,valueAccessor,allBindingsAccessor,viewModel,bindingContext){var grid=$(element),binding,options,ds,childgridhandler,key;binding=ko.utils.unwrapObservable(valueAccessor());options={};ds=ko.isObservable(binding.dataSource)?binding.dataSource():binding.dataSource;if(ds instanceof $.ig.DataSource){ds=ds.data()}options.dataSource=new $.ig.KnockoutDataSource({dataSource:binding.dataSource});for(key in binding){if(binding.hasOwnProperty(key)&&key!=="dataSource"){options[key]=binding[key]}}grid.igGridKnockoutBridge();grid.igHierarchicalGrid(options);grid.data("observableDataSource",options.dataSource);childgridhandler=function(event,args){var kods,opts=args.options,observableDs;if(args.element.data("igGrid")){return}kods=args.owner.element.data("observableDataSource");observableDs=kods.dataAt(args.id,args.path);opts.dataSource=new $.ig.KnockoutDataSource({primaryKey:opts.primaryKey,dataSource:opts.dataSource,observableDataSource:observableDs,responseDataKey:opts.responseDataKey});args.element.igGridKnockoutBridge();args.element.igGrid(opts);opts=args.element.data("igGrid").options;args.element.attr("data-create",false);ko.applyBindingsToNode(args.element[0],{igGrid:{}},observableDs)};grid.on("igchildgridcreating","table",childgridhandler);return{controlsDescendantBindings:true}},update:ko.bindingHandlers.igGrid.update};ko.bindingHandlers.igCell={update:function(element,valueAccessor,allBindingsAccessor,viewModel){var cell=$(element);cell.closest(".ui-iggrid-table").igGridKnockoutBridge("cellUpdated",cell,typeof valueAccessor==="function"?valueAccessor():valueAccessor,viewModel!==null&&ko.isObservable(viewModel.$data)?viewModel.$data():viewModel)}};(function($){$.widget("ui.igGridKnockoutBridge",{options:{parent:null},_create:function(){if(!this.options.parent){this.options.parent=this.element.data("igGrid")}this._createHandlers();this._bridgeGrid(this.element)},destroy:function(){var handler=this._rebindCellsHandler;this.options.parent.renderNewRow=this._renderNewRowDefault;if(this._grb){this._grb._renderNewRow=this._renderNewRowGroupBy}this.element.unbind({iggridrendering:this._gridRenderingHandler,iggridrendered:this._gridRenderedHandler,iggriddatarendered:handler,iggridvirtualrecordsrender:handler,iggridcolumnscollectionmodified:handler});$.Widget.prototype.destroy.apply(this,arguments);return this},renderNewRow:function(rec,key){this._renderNewRowDefault.apply(this.options.parent,[rec,key]);this._rebindCells()},_renderNewRowGroupByKo:function(rec,key){this._renderNewRowGroupBy.apply(this._grb,[rec,key]);this._rebindCells()},rebindCells:function(rowId){this._rebindCells(rowId)},_gridRendering:function(evt,ui){if(this.options.parent&&this.options.parent.id()!==ui.owner.id()){return}this.options.parent=ui.owner;if(this.renderNewRow!==ui.owner.renderNewRow){this._renderNewRowDefault=ui.owner.renderNewRow;ui.owner.renderNewRow=$.proxy(this.renderNewRow,this)}},_gridRendered:function(evt,ui){var grb=$(ui.owner.element).data("igGridGroupBy")||$("#"+ui.owner.id()).data("igGridGroupBy");if(grb&&this._renderNewRowGroupByKo!==grb._renderNewRow){this._renderNewRowGroupBy=grb._renderNewRow;grb._renderNewRow=$.proxy(this._renderNewRowGroupByKo,this);this._grb=grb}},_rebindCells:function(rowId){var ds,grid=this.element,owner=this.options.parent,gridElement=this.options.parent.element,pageIndex=gridElement.data("igGridPaging")?gridElement.data("igGridPaging").pageIndex():0,pageSize=gridElement.data("igGridPaging")?gridElement.data("igGridPaging").pageSize():0,startRowIndex=pageIndex*pageSize,opts=owner.options;if(ko.isObservable(owner.dataSource.kods)){ds=owner.dataSource.kods()}else if(ko.isObservable(owner.dataSource.kods[owner.options.responseDataKey])){ds=owner.dataSource.kods[owner.options.responseDataKey]()}else{ds=owner.dataSource.dataSource()}if(!opts.rowVirtualization&&!opts.virtualization){owner._startRowIndex=startRowIndex}owner.element.children("tbody").children("tr[data-grouprow!=true][data-container!=true]").filter(function(){return this.style.visibility!=="hidden"}).map(function(i){var tr_id=$(this).attr("data-id"),restoreGridState=false,id,k,l,cells,dataVal,rec;for(i=0;i<ds.length;i++){id=ds[i][owner.options.primaryKey];if(ko.isObservable(id)){id=id()}if(String(id)===String(tr_id)){rec=ds[i];break}}if(rec){cells=$(this).children("td[data-parent!=true][data-parent!=false][data-skip!=true]");l=0;for(k=0;k<opts.columns.length;k++){if(opts.columns[k].hidden){continue}dataVal=rec[opts.columns[k].key];if(ko.isObservable(dataVal)){if(ko.hasOwnProperty("applyBindingAccessorsToNode")){ko.applyBindingAccessorsToNode(cells[l++],{igCell:{value:opts.columns[k]}},{$data:dataVal})}else{ko.applyBindingsToNode(cells[l++],{igCell:{value:opts.columns[k]}},dataVal)}}}}else{$(this).remove()}})},recordsUpdated:function(valueAccessor){var grid=this.options.parent,newds,oldds,updating=$(this.options.parent.element).data("igGridUpdating")||$("#"+grid.id()).data("igGridUpdating"),i,key,changes,c,autoCommit=grid.options.autoCommit;newds=valueAccessor().dataSource;if(!newds){if(grid.options.responseDataKey){newds=grid.dataSource.kods[grid.options.responseDataKey]}else{newds=grid.dataSource.kods}}oldds=grid.dataSource._knockoutState;grid.dataSource._knockoutState=$.extend([],newds());if(!oldds){return}if(updating===null||updating===undefined){throw new Error("two-way adding and deleting of rows with KnockoutJS requires the Updating feature to be defined")}if(typeof newds==="function"&&!grid.dataSource._ownUpdate){changes=ko.utils.compareArrays(oldds,newds());for(i=0;i<changes.length;i++){c=changes[i];if(c.status==="deleted"){grid.dataSource._koUpdate=true;key=c.value[grid.options.primaryKey];key=ko.isObservable(key)?key():key;grid.options.autoCommit=true;updating.deleteRow(key);grid.options.autoCommit=autoCommit}else if(c.status==="added"){key=c.value[grid.options.primaryKey];key=ko.isObservable(key)?key():key;grid.dataSource._koUpdate=true;grid.options.autoCommit=true;updating.addRow(ko.toJS(c.value));grid.options.autoCommit=autoCommit}}}grid.dataSource._ownUpdate=false},cellUpdated:function(cell,valueAccessor,viewModel){var table=cell.closest(".ui-iggrid-table"),grid=this.options.parent,key,tmpldata={},newFormattedVal,tr,rec,keyVal,col;key=valueAccessor.value.key;if(grid.options.rowTemplate&&grid.options.rowTemplate.length>0){tmpldata[key]=viewModel;newFormattedVal=grid._renderTemplatedCell(tmpldata,valueAccessor.value).substring(1)}else{newFormattedVal=grid._renderCell(viewModel,valueAccessor.value)}cell.html(newFormattedVal);tr=cell.closest("tr");col=grid.columnByKey(grid.options.primaryKey);if(tr.attr("data-id")!==null&&tr.attr("data-id")!==undefined){if(col.dataType==="number"||col.dataType===undefined){keyVal=parseInt(tr.attr("data-id"),10);if(key===grid.options.primaryKey){viewModel=parseInt(viewModel,10)}}else{keyVal=tr.attr("data-id")}rec=grid.dataSource.findRecordByKey(keyVal);if(rec===null){rec=grid.dataSource.findRecordByKey(viewModel)}if(key===grid.options.primaryKey){tr.attr("data-id",viewModel);tr.data().id=viewModel}rec[key]=viewModel}else{throw new Error("Updating the data source requires a primary key to be defined")}grid.dataSource._ownUpdate=false},_bridgeGrid:function(grid){var handler=this._rebindCellsHandler;grid.bind({iggridrendering:this._gridRenderingHandler,iggridrendered:this._gridRenderedHandler,iggriddatarendered:handler,iggridvirtualrecordsrender:handler,iggridcolumnscollectionmodified:handler})},_createHandlers:function(){this._rebindCellsHandler=$.proxy(this._rebindCells,this);this._gridRenderingHandler=$.proxy(this._gridRendering,this);this._gridRenderedHandler=$.proxy(this._gridRendered,this)}})})(jQuery);(function($){$(document).ready(function(){var wm=$("#__ig_wm__").length>0?$("#__ig_wm__"):$('<div id="__ig_wm__"></div>').appendTo(document.body);wm.css({position:"fixed",bottom:0,right:0,zIndex:1e3})})})(jQuery);
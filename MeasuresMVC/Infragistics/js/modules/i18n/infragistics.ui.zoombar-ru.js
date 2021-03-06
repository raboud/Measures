﻿/*!@license
* Infragistics.Web.ClientUI Zoombar localization resources 13.2.20132.2157
*
* Copyright (c) 2011-2014 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global jQuery */
(function ($) {
    $.ig = $.ig || {};

    if (!$.ig.Zoombar) {
	    $.ig.Zoombar = {};

	    $.extend($.ig.Zoombar, {

	        locale: {
	            zoombarTargetNotSpecified: "Виджету igZoombar необходим целевой объект для отображения!",
			    zoombarTypeNotSupported: "Целевой виджет, к которому Zoombar пытается присоединиться, не поддерживается!",
			    optionChangeNotSupported: "Изменение этой опции после создания igZoombar не поддерживается:"
		    }
	    });

    }
})(jQuery);
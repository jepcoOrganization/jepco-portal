/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    //config.filebrowserBrowseUrl = '/Siteware/FileBrowser/NewBros.aspx?caller=parent&fn=fileBrowserCallBack2&langCode=en',    
    config.enterMode = CKEDITOR.ENTER_BR;
    config.extraPlugins = 'filebrowser';
    config.filebrowserBrowseUrl = '/Siteware/FileBrowser/NewBros.aspx?type=image'; //&CKEditor=editor2&CKEditorFuncNum=2&langCode=de
    config.baseUrl = "http://wol.aura-techs.com/";
    config.baseHref = 'http://wol.aura-techs.com/';
    config.extraPlugins = 'popup';
    config.allowedContent = true;
    config.extraAllowedContent = 'span(*)';
    config.extraAllowedContent = 'i(*)';
    config.extraAllowedContent = 'section(*)';   
    CKEDITOR.dtd.$removeEmpty.i = 0;
    config.protectedSource.push(/<i class[\s\S]*?\>/g);
    config.protectedSource.push(/<\/i>/g);
    CKEDITOR.dtd.$removeEmpty['span'] = false;
    CKEDITOR.dtd.$removeEmpty['i'] = false;
    CKEDITOR.dtd.$removeEmpty['div'] = false;
};

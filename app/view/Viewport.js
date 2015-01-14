Ext.define('App.view.Viewport', {
    extend: 'Ext.container.Viewport',
    controller: 'viewport',
    requires: ['Ext.grid.Panel'],
    style: 'padding:25px',
    layout: 'vbox',
    items: [
       {
           xtype: 'gridpanel',
           reference: 'modelCarsGrid',
           width: 650,
           height: 355,
           title: 'Ext JS Grid - Search With C# Backend',
           store: 'Albums',
           columns: [
                {
                    text: 'Id',
                    hidden: true,
                    dataIndex: 'id'
                },
                {
                    text: 'Title',
                    sortable: true,
                    dataIndex: 'title',
                    flex: 3,
                    sortable: false
                },
                {
                    text: 'Artist',
                    sortable: true,
                    dataIndex: 'artistName',
                    flex: 2,
                    sortable: false
                }
           ],
           dockedItems: [
               {
                   xtype: 'toolbar',
                   dock: 'top',
                   items: [
                       {
                           xtype: 'textfield',
                           fieldLabel: 'Search',
                           enableKeyEvents: true,
                           listeners: {
                               keyup: 'onSearchFieldKeyUp',
                               buffer:300
                           }
                       }
                   ]
               }
           ]
       }
    ]
});
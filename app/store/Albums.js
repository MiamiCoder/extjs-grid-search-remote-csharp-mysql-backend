Ext.define('App.store.Albums', {
    extend: 'Ext.data.Store',
    model: 'App.model.Album',
    proxy: {
        type: 'rest',
        url: '../../../api/GridSearchRemoteExample',
        reader: {
            type: 'json',
            rootProperty: 'albums',
            totalProperty: 'count'
        }
    },
    autoLoad: true,
    remoteFilter: true
});
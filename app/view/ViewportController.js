Ext.define('App.view.ViewportController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.viewport',
    onSearchFieldKeyUp: function (field, evt, eOpts) {
        var searchString = field.getValue(),
            grid = this.lookupReference('modelCarsGrid'),
            store = grid.getStore(),
            filters = [];

        if (searchString) {

            this.titleFilter = filters.push({
                id: 'titleFilter',
                property: 'title',
                value: searchString,
                anyMatch: true,
                caseSensitive: false
            });

            this.artistFilter = filters.push({
                id: 'artistFilter',
                property: 'artistName',
                value: searchString,
                anyMatch: true,
                caseSensitive: false
            });

        } 

        store.setFilters(filters);
    }
});
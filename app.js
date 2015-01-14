Ext.application({
    name: 'App',
    models: ['Album'],
    stores: ['Albums'],
    views: ['Viewport','ViewportController'],
    autoCreateViewport: true
});
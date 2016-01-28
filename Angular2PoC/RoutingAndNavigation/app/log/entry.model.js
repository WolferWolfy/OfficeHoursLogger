System.register([], function(exports_1) {
    var EntryModel;
    return {
        setters:[],
        execute: function() {
            EntryModel = (function () {
                function EntryModel(id, name, date) {
                    this.id = id;
                    this.name = name;
                    this.date = date;
                }
                EntryModel.prototype.getTime = function () {
                    return ("0" + (this.date.getHours())).slice(-2) + ":" + ("0" + (this.date.getMinutes())).slice(-2); //+ ":" + ("0" + (this.date.getSeconds())).slice(-2);
                };
                return EntryModel;
            })();
            exports_1("EntryModel", EntryModel);
        }
    }
});
//# sourceMappingURL=entry.model.js.map
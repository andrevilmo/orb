var model;
var modelUrl = window.urlApi + "odata/Usuario";
$(document).ready(function () {
    var PagedGridModel = function (items) {
        var self = this;
        this.items = ko.observableArray(items);
        this.selectedItem = ko.observable(-1);
        this.Selected = ko.observable(null);
        this.Cliente = ko.observable();
        this.Clientes = ko.observableArray();
        this.Perfis = ko.observableArray();
        this.loadItems = function () {
            $.ajax({
                url: modelUrl,
                type: 'GET',
                error: function (xhr, status) {
                    //console.log(status);
                },
                success: function (result) {
                    $(result.value).each(function () {
                        model.items.push(ko.mapping.fromJS(this));
                    });
                    ko.applyBindings(model);
                    $("div.kgViewport").css("height", "inherit");
                    $("div.gridstyle").css("margin-top", "-25px");
                    applyEvents(function (index) {
                        model.selectedItem(index);
                    });
                }
            });
            $.ajax({
                url: window.urlApi + "odata/Cliente",
                type: 'GET',
                error: function (xhr, status) {
                    //console.log(status);
                },
                success: function (result) {
                    $(result.value).each(function () {
                        model.Clientes.push(ko.mapping.fromJS(this));
                    });
                }
            });
            $.ajax({
                url: window.urlApi + "odata/Perfil",
                type: 'GET',
                error: function (xhr, status) {
                    //console.log(status);
                },
                success: function (result) {
                    $(result.value).each(function () {
                        model.Perfis.push(ko.mapping.fromJS(this));
                    });
                }
            });
        };
        this.addItem = function () {
            var novoItem = ko.mapping.fromJS({ ClienteId: ko.observable(0), Nome: ko.observable(""), SobreNome: ko.observable(""), Login: ko.observable(""), Senha: ko.observable(""), Email: ko.observable(""), Email: ko.observable(""), Telefone: ko.observable(""), Celular: ko.observable(""), DataSuspensao: ko.observable(""), PerfilId: ko.observable(0) });
            this.Selected(novoItem);
            $('#powerwidgets').css('visibility', 'visible');
            $('.fa-chevron-circle-up').click();
            $('.fa-chevron-circle-down').click();
            applyMasks();
        };
        this.salvar = function () {
            var toSend = ko.utils.stringifyJson(ko.mapping.toJS(this.Selected()));
            //console.log(this.Selected());
            //console.log(toSend);
            $.ajax({
                url: this.Selected().Id != null ? modelUrl + "(" + model.Selected().Id() + ")"
                                            : modelUrl,
                type: this.Selected().Id != null ? "PUT" : "POST",
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                data: toSend,
                error: function (xhr, status) {
                    //console.log(status);
                },
                success: function (result) {
                    var saved = ko.mapping.fromJS(result);
                    if (result) {
                        model.Selected(saved);
                        model.Selected().Id = ko.observable(saved.Id());
                        model.items.push(model.Selected());
                    }
                    if (model.Cliente())
                        if (result)
                            saverel(saved.Id(), model.Cliente(), "clientedosimcard", function (data) {
                                //console.log(data);
                            });
                        else
                            saverel(model.Selected().Id(), model.Cliente(), "clientedosimcard", function (data) {
                                //console.log(data);
                            });
                    $('#powerwidgets').css('visibility', 'hidden');
                    $('.fa-chevron-circle-up').click();
                    applyEvents(function (index) {
                        model.selectedItem(index);
                    });
                    model.items.valueHasMutated();
                }
            });
        };
        this.refresh = function (data) {
            //console.log(data);
        };
        this.gridOptions = {
            data: self.items
            , footerVisible: false
            , multiSelect: false
            , showColumnMenu: false
            , showFilter: false
            , displaySelectionCheckbox: false
            , afterSelectionChange: function (grid) {
                model.Selected(grid.selectedItems()[0]);
                $(model.Clientes()).each(function () {
                    if (this.Id() == model.Selected().ClienteId()) {
                        model.Selected().ClienteId(this);
                        return;
                    }
                });
                $(model.Perfis()).each(function () {
                    if (this.Id() == model.Selected().PerfilId()) {
                        model.Selected().PerfilId(this);
                        return;
                    }
                });
                $('#powerwidgets').css('visibility', 'visible');
                $('.fa-chevron-circle-down').click();
                $('html,body').animate({ 'scrollTop': 0 }, 1000);
                
            }
            , columnDefs: [
                { field: "Nome", displayName: "Nome" },
                { field: "SobreNome", displayName: "Sobrenome" }
            ]
        };
    };
    model = new PagedGridModel();
    model.loadItems();
});
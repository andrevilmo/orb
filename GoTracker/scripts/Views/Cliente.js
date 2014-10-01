var model;
$(document).ready(function () {
    var PagedGridModel = function (items) {
        var self = this;
        this.items = ko.observableArray(items);
        this.selectedItem = ko.observable(-1);
        this.Selected = ko.observable(null);
        this.Pai = ko.observable();
        this.loadItems = function () {
            $.ajax({
                url: window.urlApi + "odata/Cliente",
                type: 'GET',
                error: function (xhr, status) {
                    console.log(status);
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
        };
        this.addItem = function () {
            var novoItem = ko.mapping.fromJS({ Nome: ko.observable(""), Estado: ko.observable(""), ClienteId: ko.observable(""), CNPJ: ko.observable(""), Email: ko.observable(""), Telefone: ko.observable(""), Logradouro: ko.observable(""), Cidade: ko.observable(""), Estado: ko.observable(""), WebSite: ko.observable(""), Observacoes: ko.observable("") });
            this.Selected(novoItem);
            //this.selectedItem(this.items.push(novoItem) - 1);
            $('#powerwidgets').css('visibility', 'visible');
            $('.fa-chevron-circle-up').click();
            $('.fa-chevron-circle-down').click();
            //$($(".ko-grid tbody tr")[this.selectedItem()]).hide();
            applyMasks();
        };
        this.salvar = function () {
            var toSend = ko.utils.stringifyJson(ko.mapping.toJS(this.Selected()));//(ko.utils.stringifyJson(this.Selected()));
            $.ajax({
                url: this.Selected().Id != null ? window.urlApi + "odata/Cliente(" + model.Selected().Id() + ")"
                                            : window.urlApi + "odata/Cliente",
                type: this.Selected().Id != null ? "PUT" : "POST",
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                data: toSend,
                error: function (xhr, status) {
                    console.log(status);
                },
                success: function (result) {
                    var saved = ko.mapping.fromJS(result);
                    if (result) {
                        model.Selected(saved);
                        model.Selected().Id = ko.observable(saved.Id());
                        model.items.push(model.Selected());
                    }
                    if (model.Pai())
                        if (result)
                            saverel(saved.Id(), model.Pai(), "clientefilhode", function (data) {
                                console.log(data);
                            });
                        else
                            saverel(model.Selected().Id(), model.Pai(), "clientefilhode", function (data) {
                                console.log(data);
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
        this.gridViewModel = new ko.simpleGrid.viewModel({
            data: this.items,
            columns: [
                { headerText: "Nome", rowText: "Nome()" },
                { headerText: "CNPJ", rowText: "CNPJ()" },
                { headerText: "Email", rowText: "Email()" },
                { headerText: "Telefone", rowText: "Telefone()" },
                { headerText: "Logradouro", rowText: "Logradouro()" },
                { headerText: "Cidade", rowText: "Cidade()" },
                { headerText: "UF", rowText: "Estado()" },
                { headerText: "Site", rowText: "WebSite()" },
                { headerText: "Observações", rowText: "Observacoes()" }
            ],
            pageSize: 10
        });
        this.gridOptions = {
            data: self.items
            , footerVisible: false
            , multiSelect: false
            , showColumnMenu: false
            , showFilter: false
            , displaySelectionCheckbox: false
            , afterSelectionChange: function (grid) {
                model.Selected(grid.selectedItems()[0]);
                $('#powerwidgets').css('visibility', 'visible');
                $('.fa-chevron-circle-down').click();
                $('html,body').animate({ 'scrollTop': 0 }, 1000);
                $.get(window.urlApi + "odata/Cliente(" + model.Selected().Id() + ")/ClienteFilhoDe", function (data) {
                    model.Pai(ko.mapping.fromJS(data));
                }).fail(function () {
                    model.Pai(null);
                });
            }
            , columnDefs: [
                { field: 'Nome', displayName: 'Nome' }
                , { field: 'CNPJ', displayName: 'CNPJ' }
                , { field: 'Email', displayName: 'Email' }
                , { field: 'Telefone', displayName: 'Telefone' }
                , { field: 'Logradouro', displayName: 'Logradouro' }
                , { field: 'Cidade', displayName: 'Cidade' }
                , { field: 'Estado', displayName: 'Estado' }
                , { field: 'WebSite', displayName: 'WebSite' }
                , { field: 'Observacoes', displayName: 'Observações' }
            ]
        };
    };
    model = new PagedGridModel();
    model.loadItems();
});
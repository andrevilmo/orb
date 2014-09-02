
ko.bindingHandlers.Select = {
    _self : this,
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        element.DisplayField = allBindings.get('DisplayField');
        element.ValueField = allBindings.get('ValueField');
        element.allBindings = allBindings;
        element.bindingContext = bindingContext;
        element.valueAccessor = valueAccessor;
        //console.log('Init - Select');
        //console.log(valueAccessor());
        // This will be called when the binding is first applied to an element
        // Set up any initial state, event handlers, etc. here
        $('body').append("<div style='display:none' id='hiddenDiv'></div>");
        if (this.element) {
            var objSel = $('#' + self.element.id);
            var magicobj = objSel.magicSuggest({
                data: typeof (allBindings.get('SelectableItems')) == "function" ? allBindings.get('SelectableItems')() : allBindings.get('SelectableItems'),
                displayField: allBindings.get('DisplayField'),
                maxSelection: 1,
                valueField: allBindings.get('ValueField'),
                maxSelectionRenderer: function (v,vl) {
                    return "";
                }
                , selectionContainer: $('#hiddenDiv')
                //value: valueAccessor()
            });
            if (magicobj)
                $(magicobj).on('selectionchange', function (e, m) {
                    console.log("values: " + JSON.stringify(this.getSelection()));
                    model.Selected()[self.allBindings().SetField] = this.getSelection()[0][self.allBindings().ValueField];
                    /*if (typeof (model[self.allBindings().SetField]) == 'function')
                        model[self.allBindings().SetField](this.getSelection()[0]);//model.Pai(this.getSelection()[0]);
                    else
                        model.Selected()[self.allBindings().SetField](this.getSelection()[0][self.allBindings().ValueField]);
                    */model.Selected(model.Selected);

                });
        }

    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        // This will be called once when the binding is first applied to an element,
        // and again whenever any observables/computeds that are accessed change
        // Update the DOM element based on the supplied values here.
    }
};
var PagedGridModel = function (items) {
    var self = this;
    this.items = ko.observableArray(items);
    this.selectedItem = ko.observable(-1);
    this.Selected = ko.observable();
    this.Pai = ko.observable();
    this.SelectedOriginal = ko.observable();
    this.IsSelected = ko.computed(function () {
        this.Selected(this.items()[this.selectedItem()]);
        //console.log(ko.mapping.fromJS(this.Selected()));
        if (this.selectedItem()>-1)
            $.get("http://localhost:9961/odata/Cliente(" + this.Selected().Id + ")/ClienteFilhoDe", function (result) {
                self.Pai(result);
            }).fail(function () {
                self.Pai(null);
            });
        return this.selectedItem() > -1;
    }, this);
    this.addItem = function () {
        var novo = this.items.push({ Nome: '',Estado:'' });
        this.selectedItem(model.items().length - 1);
        $('#powerwidgets').css('visibility', 'visible');
        $('.fa-chevron-circle-up').click();
        $('.fa-chevron-circle-down').click();
        $($(".ko-grid tbody tr")[model.items().length - 1]).hide();
        //this.items.push({ name: "Novo Cliente", sales: 0, price: 100 });
    };
    this.sortByName = function () {
        this.items.sort(function (a, b) {
            return a.name < b.name ? -1 : 1;
        });
    };
    this.jumpToFirstPage = function () {
        this.gridViewModel.currentPageIndex(0);
    };
    this.gridViewModel = new ko.simpleGrid.viewModel({
        data: this.items,
        columns: [
            { headerText: "Nome", rowText: "Nome" },
            { headerText: "CNPJ", rowText: "CNPJ" },
            { headerText: "Email", rowText: "Email" },
            { headerText: "Telefone", rowText: "Telefone" },
            { headerText: "Logradouro", rowText: "Logradouro" },
            { headerText: "Cidade", rowText: "Cidade" },
            { headerText: "UF", rowText: "Estado" },
            { headerText: "Site", rowText: "WebSite" },
            { headerText: "Observações", rowText: "Observacoes" }
        ],
        pageSize: 10
    });
};
var model = null;
$(document).ready(function () {
    $.ajax({
        url: "http://localhost:9961/odata/Cliente",
        type: 'GET',
        error: function (xhr, status) {
            console.log(status);
        },
        success: function (result) {
            $('.fa-chevron-circle-up').click();
            $('#powerwidgets').css('visibility', 'visible');
            model = new PagedGridModel((result.value));
            ko.applyBindings(model);
            $('#listaClientes table').addClass("table table-striped table-bordered table-condensed table-hover");
            $('.ko-grid-pageLinks span').html('Pág.');
            $('.ko-grid tbody tr td').click(function (ev, ev1) {
                var selectedIndex = $($(ev.target).parent())[0].rowIndex - 1;
                model.selectedItem(selectedIndex);
                $('#powerwidgets').css('visibility', 'visible');
                $('.fa-chevron-circle-down').click();
            });
        }
    });
});

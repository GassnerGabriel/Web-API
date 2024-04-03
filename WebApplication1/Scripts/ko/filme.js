var FilmeModel = new function () {
    model = this
    model.filmes = ko.observable([
        {
            "Codigo": 1,
            "Titulo": "O Poderoso Chefão",
            "Ano": "1972",
            "Genero": "Drama, Crime",
            "Produtora": "Paramount Pictures"
        }
    ]);
    model.carregar = function () {
        var settings = {
            "url": "http://localhost:50751/api/Filmes",
            "method": "GET",
            "timeout": 0,
        };

        $.ajax(settings).done(function (response) {
            model.filmes(response);
        });
    };
    model.carregar();
}

ko.applyBindings(FilmeModel);
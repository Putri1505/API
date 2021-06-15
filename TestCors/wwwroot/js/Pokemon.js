////$.ajax({
////    url: 'https://pokeapi.co/api/v2/pokemon/'
////}).done((result) => {
////    console.log(result.results);
////    text = "";
////    $.each(result.results, function (key, val) {
////        //console.log(val.name);
////        text += `<tr>
////                        <td>${val.name}</td>
////                        <td>${val.url}</td>
////                        <td><button type="button" class="btn btn-primary" onclick= "detail('${val.url}')" data-toggle="modal" data-target="#detailmodal">Detail</button></td>
////                 </tr>`
////    })
////    $('#bodyPokemon').html(text);
////}).fail((error) => {
////    console.log(error);
////});

function detail(Url) {

    $.ajax({
        url: Url
    }).done((result) => {
        text2 = "";
        text2 += `<center><h4>Name: ${result.name}</h4>
                    <img src="${result.sprites.back_default}" alt="" />
                     <h4>height: ${result.height}</h4>
                      <h4>order: ${result.order}</h4></center>`;

        $('#modalPoke').html(text2);
    }).fail((error) => {
        console.log(error);
    });
}

$(document).ready(function () {
    $('#tablePoke').DataTable({
        ajax:{
            url: 'https://pokeapi.co/api/v2/pokemon/',
            dataSrc: 'results'
        },
        columns: [
            {
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "name"
                //"render": function (data, type, row) {
                //return row['name']
               // }
            },
            {
                "data":"url"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick= "detail('${row.url}')" data-toggle="modal" data-target="#detailmodal">Detail</button>`;
                }
            }
        ]
    });
});

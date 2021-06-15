////var judul = document.getElementById('title');
////judul.style.color = 'salmon';
////judul.style.background = 'lightgreen';

//var p = document.getElementsByTagName('p');
//for (var i = 0; i < p.length; i++) {
//    p[i].style.color = 'red';
//}

//var p1 = document.getElementsByClassName('pa')[0];
//p1.style.color = 'red';
//pa.style.color = 'salmon';

//var query = document.querySelector('hanyaini');
//query.style.color = 'salmon';
//query.innerHTML = 'halo ini di ubah dari js';

//var query = document.querySelector('section#b #a ul li:nth-child(2)');
//query.addEventListener('mouseover', function () {
//    query.innerHTML = 'halo ini di ubah dari js';
//    query.style.color = 'red';
//});
//query.addEventListener('mouseleave', function () {
//    query.innerHTML = 'berubah';
//    query.style.color = 'blue';
//});
//var p1 = document.getElementsByClassName('paragraf1')
//var btn = document.getElementById('button');
//btn.addEventListener('click', function () {
//    p1[0].style.color = 'red';
//});
//$('.button').on('click', function (e) {
//    e.preventDefault;
//});
//array 1 dimensi
//let array = [1, 2, 3, 4];
//console.log(array);
////array multidimensi
//let arraymulti = ['a', 'b', 'c', 1, 2, ['e', 3, 'f'], true];
//console.log(arraymulti[5][1]);
////akses array with loop
//let element = null;
//for (var i = 0; i < array.length; i++) {
//    element = array[i];
//}
//console.log(element);
//array.push(5);
//array.push('hello');
//array.pop();

//let mahasiswa = {
//    nama: 'Putri',
//    nim: 'abc',
//    hobby: ['makan', 'olahraga']
//}
//console.log(mahasiswa.nama);
//console.log(mahasiswa.hobby[1]);

//let mhs = {}
//mhs.nama = 'said';
//mhs.nim = '12a';
//mhs.location = 'Jakarta';
//console.log(mhs);

//const hitung = (num1, num2 = 10) => {
//    const jumlah = num1 * num2;
//    return jumlah;
//}
//console.log(hitung(6));
//const animals = [
//    { name: "tom", species: "cat", class: { name: 'mamalia' } },
//    {name: "jerry", species: "dog", class: { name: 'mamalia' }},
//    { name: "garry", species: "snail", class: { name: 'invertebrata' } },
//    { name: "gery", species: "snail", class: { name: 'invertebrata'} },
//    { name: "garry", species: "snail", class: { name: 'invertebrata' } },
//    { name: "garfield", species: "cat", class: { name: 'mamalia' } },
//    { name: "garger", species: "snail", class: { name: 'invertebrata' } },
//    { name: "gargery", species: "dog", class: { name: 'mamalia' } },
//];
//console.log(animals);
//const onlyCat = animals.filter(animals => animals.species == 'cat');
//const onlyDog = animals.filter(animals => animals.species == 'dog');
//const onlySnail = animals.filter(animals => animals.species == 'snail');
//console.log(onlyDog);
//console.log(onlyCat);
//console.log(onlySnail);

//let invertebrata = [];
//for (let i = 0; i < animals.length; i++) {
//    if (animals[i].class.name == 'invertebrata') {
//        animals[i].class.name = 'Non Mamalia';
//    }
//    console.log(animals[i]);
//}
//console.log(animals[2].class.name);

//for (var i = 0; i < animals.length; i++) {
//    if (animals[i].species == 'cat') {
//        onlyCat.push(animals[i]);
//    }
//}
//console.log(animals[2].class.name);
$.ajax({
    //url: 'https://pokeapi.co/api/v2/pokemon/'
    url: 'https://swapi.dev/api/people/'
}).done((result) => {
    console.log(result.results);
    text = "";
    $.each(result.results, function (key, val) {
        //console.log(val.name);
        text += `<tr>
                        <td>${val.name}</td>
                        <td>${val.height} cm</td>
                        <td>${val.gender}</td>
                        <td><button type="button" class="btn btn-primary" onclick= "detail('${val.url}')" data-toggle="modal" data-target="#detailmodal">Detail</button></td>
                 </tr>`
    })
    $('#tablesw').html(text);
}).fail((error) => {
    console.log(error);
});

function detail(stringUrl) {
    let url2 = stringUrl.substring(stringUrl.length - 2)

    $.ajax({
        url: 'https://swapi.dev/api/people/' + url2
    }).done((result) => {
        text2 = "";
        text2 += `<h4>Name: ${result.name}</h4>
                <h4>Gender: ${result.gender}</h4>
                <h4>Mass: ${result.mass}</h4>
                <h4>Hair Color: ${result.hair_color}</h4>`;
       
        $('#modalsw').html(text2);
    }).fail((error) => {
        console.log(error);
    });
}





















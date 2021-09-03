//todoArray endArray

let trial = document.getElementById("mySelect");
let selectCount = trial.length;

let todayArray = [];
let backToday = [];

for (var i = 1; i <= selectCount; i++) {
    let hello = $("#" + i).val();
    todayArray.push(hello);
}


let todayList = ["", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", ""];
let endArray = [];
for (var i = 0; i <= todayArray.length - 1; i++) {
    let gununAdi = todayArray[i];
    let todayIndex = todayList.indexOf(gununAdi);
    endArray.push(todayList[todayIndex + 1]);
    backToday.push(todayList[todayIndex - 1]);
}

console.log("Geri Sayaç => ", backToday);


let getirTrue = document.getElementsByClassName("gunduz");
let selamBtn = document.getElementsByClassName("selamBtn");
let labelText = document.getElementById("labelText");
let dropDown = document.getElementById("lst");
let dropKad = document.getElementById("dropKad");

for (var i = 0; i < 5; i++) {
    if (getirTrue[i].textContent == "True") {
        getirTrue[i].textContent = "Boş";
        getirTrue[i].classList.add("table-success");
    }
    else {
        getirTrue[i].textContent = "Dolu";
        getirTrue[i].classList.add("table-danger");
    }
}


let getirTrueGece = document.getElementsByClassName("gece");

for (var i = 0; i < 5; i++) {
    if (getirTrueGece[i].textContent == "True") {
        getirTrueGece[i].textContent = "Boş";
        getirTrueGece[i].classList.add("table-success");

    }
    else {
        getirTrueGece[i].textContent = "Dolu";
        getirTrueGece[i].classList.add("table-danger");


    }
}

//const bul = dropDown[0].textContent.indexOf("(");
//console.log(dropDown[0].textContent.substring(0, bul));
console.log("selam kardeş");
console.log("Burası mı ?  ", todayArray);

console.log(endArray);

$("#sendDropdown").click(function (e) {
    var dropdownValue = document.getElementById("lst");
    var dropdownText = dropdownValue.options[dropdownValue.selectedIndex].text;
    const bul = dropdownText.indexOf("(");
    let dropTextsubstring = dropdownText.substring(0, bul)


    if (dropTextsubstring === endArray[0] || dropTextsubstring === endArray[1] || dropTextsubstring === endArray[2] || dropTextsubstring === todayArray[0] || dropTextsubstring === todayArray[1] || dropTextsubstring === backToday[0] || dropTextsubstring === backToday[1] && dropTextsubstring != "") {
        //console.log("DropdownText => ", dropTextsubstring, "| Dizi", endArray[0]);
        Swal.fire({
            icon: 'error',
            title: 'Art Arda Gün Seçemezsin ve ya Aynı Günün İki Vardiyasını Seçemezsin',
            confirmButtonText: "Tamam",
        });

        //console.log(dropTextsubstring, " = > >  > ", todayArray[0]);


    }
    else {
        //Kontrol Vardiya
        $("#sendDropdown").hide(0);
        setTimeout(() => {
            window.location.reload();
        }, 1500)
        let kontrolSayi = Number(labelText.textContent);

        if (kontrolSayi === 0) {
            dropDown.setAttribute("disabled", "disabled");

            Swal.fire({
                icon: 'error',
                title: '1 Hafta İçinde 3 günden Fazla Çalışma Etkinliği Seçemezsiniz',
                confirmButtonText: "Tamam",
            });

        }
        else {

            var requestData = {
                ID: $.trim(dropDown.value),
                Durum: false,
                CalisanKisi: $.trim(dropKad.value),
            }

            //Burası Post Tarafı

            $.ajax({
                url: "/PerIslem/Index",
                type: "POST",
                data: JSON.stringify(requestData),
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
            });

            Swal.fire({
                icon: 'success',
                title: 'Çalışma Etkinliği Başarı Bir Şekilde Oluşturuldu',
                confirmButtonText: "Tamam",
            });


            // Çalışma Zamanlarını Çalışma Takvime Gönderme İşlemi



            var calsimaTakvim = {
                CalismaGunu: $.trim(dropDown.value),
            }

            $.ajax({
                url: "/PerIslem/TkvmCalismaEkle",
                type: "POST",
                data: JSON.stringify(calsimaTakvim),
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
            });


        }
    }






});


//Get olduğunda

let kontrolSayi = Number(labelText.textContent);

if (kontrolSayi === 0) {
    dropDown.setAttribute("disabled", "disabled");
}


      //let selectOptions = document.getElementsByTagName("option");
            //let asd = $("#falseSayisi").text();




            ////Günleri Listele
            //for (var i = 0; i <= selectOptions.length - asd; i++) {
            //    //console.log(selectOptions[i]);
            //    //console.log(selectOptions[i].textContent);
            //    const bul = selectOptions[i].textContent.indexOf("(");
            //    const gunler = selectOptions[i].textContent.substring(0, bul);
            //    todayList.push(gunler);

            //}


            //console.log("dropValue =>", dropValue);
            //console.log("Tümü", selectOptions);
            //console.log(dropDown.value);



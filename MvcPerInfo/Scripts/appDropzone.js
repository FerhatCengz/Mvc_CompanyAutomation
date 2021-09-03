Dropzone.autoDiscover = false;
$("#mydropzone").dropzone({

    url: "/Profil/dropzoneUpload",
    autoProcessQueue: false,
    paramName: "file",
    dictDefaultMessage: "Fotoğrafınızı Sürükle / Bırak Yaparak Seçebilirsiniz",
    maxFiles: 1,
    dictMaxFilesExceeded: "En fazla 1 Dosya Gönderebilirsiniz",
    maxFilesize: 2,
    dictFileTooBig: "Dosya boyutu fazla - Max:2Mb",
    acceptedFiles: ".jpg,.png",
    dictInvalidFileType: "Geçersiz dosya tipi (.png ve .jpg) olmalı !",
    addRemoveLinks: true,
    dictRemoveFile: "Dosyayı Kaldır",


    init: function () {

        const dz = this;

        let Kadd = document.getElementById("Kullanici");
        this.on("sending", function (image, xhr, formData) { formData.append("resimAdi", Kadd.value); });

        $(document).on("click", "#selectDropzone", function (e) {
            dz.processQueue();
        });


        dz.on("error", function (file) {
            window.location.reload();
        });

        dz.on("success", function (file) {
            Swal.fire({
                icon: 'success',
                title: 'Resminiz Başarılı Bir Şekilde Yüklendi !',
                confirmButtonText: 'Tamam',

            });
        });

    },
    transformFile: function (file, done) {

        var myDropZone = this;

        // Create the image editor overlay
        var editor = document.createElement('div');
        editor.style.position = 'fixed';
        editor.style.left = 0;
        editor.style.right = 0;
        editor.style.top = 0;
        editor.style.bottom = 0;
        editor.style.zIndex = 9999;
        editor.style.backgroundColor = '#000';

        // Create the confirm button
        var confirm = document.createElement('button');
        confirm.style.position = 'absolute';
        confirm.style.left = '10px';
        confirm.style.top = '10px';
        confirm.style.zIndex = 9999;
        confirm.textContent = 'Kırp ve Gönder';
        confirm.classList = "btn btn-warning";
        confirm.addEventListener('click', function () {

            // Get the canvas with image data from Cropper.js
            var canvas = cropper.getCroppedCanvas({
                width: 256,
                height: 256
            });

            // Turn the canvas into a Blob (file object without a name)
            canvas.toBlob(function (blob) {

                // Update the image thumbnail with the new image data
                myDropZone.createThumbnail(
                    blob,
                    myDropZone.options.thumbnailWidth,
                    myDropZone.options.thumbnailHeight,
                    myDropZone.options.thumbnailMethod,
                    false,
                    function (dataURL) {

                        // Update the Dropzone file thumbnail
                        myDropZone.emit('thumbnail', file, dataURL);

                        // Return modified file to dropzone
                        done(blob);
                    }
                );

            });

            // Remove the editor from view
            editor.parentNode.removeChild(editor);

        });
        editor.appendChild(confirm);

        // Load the image
        var image = new Image();
        image.src = URL.createObjectURL(file);
        editor.appendChild(image);

        // Append the editor to the page
        document.body.appendChild(editor);

        // Create Cropper.js and pass image
        var cropper = new Cropper(image, {
            aspectRatio: 1
        });

    }



});




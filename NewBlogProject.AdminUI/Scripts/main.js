$(document).ready(function () {
    $("#myTable").DataTable({
       
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "lengthMenu": "İlk _MENU_ kaydı göster",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            buttons: {
                pageLength: {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    '-1': "Tüm kayıtlar seçildi"
                },
            }
        },
        dom: 'Bfrtip',
        lengthMenu: [
            [10, 25, 50, -1],
            ['10 ', '25 ', '50 ', 'Tümünü göster'],
        ],
        buttons: [
            'pageLength', 'copy', 'csv', 'excel', 'pdf', 'print'
        ],

    });

    if ($("textarea").length > 0) {
        CKEDITOR.replace('editor1', {
            filebrowserUploadUrl: '~/Images/Uploads',
            filebrowserImageUploadUrl: '~/Images/Uploads'
        });
    }

    $("[data-toggle=tooltip]").tooltip();

});



//$('p').click(function () {
//        alert("The paragraph was clicked.");
//    });
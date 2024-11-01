function fillPageId(page) {
    $("#Page").val(page);
    $("#filter-search").submit();
}

function ShowMessage(title, text, theme) {
    window.createNotification({
        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-bottom-right',
        showDuration: 5000,
        theme: theme !== '' ? theme : 'success',
    })({
        title: title !== '' ? title : 'اعلان',
        message: text
    });
}

function deleteReport(id) {
    swal({
        title: "آیا مطمئن هستی ؟",
        text: "در صورت انجام این عملیات قادر به بازگردانی آن نمی باشید.",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/admin/Report/DeleteReport",
                    type: "post",
                    data: {
                        id: id
                    },
                    beforeSend: function () {

                    },
                    success: function (response) {
                        if (response.status === "error") {
                            swal({
                                title: "خطا",
                                text: response.message,
                                icon: "error",
                                button: "باشه"
                            });
                        }
                        else {
                            $(`#report-row-${id}`).fadeOut(500);
                            swal({
                                title: "اعلان",
                                text: response.message,
                                icon: "success",
                                button: "باشه"
                            });
                        }
                    },
                    error: function () {
                        swal({
                            title: "خطا",
                            text: "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .",
                            icon: "error",
                            button: "باشه"
                        });
                    }
                });
            }
        });
}

function deleteReportGroup(id) {
    swal({
        title: "آیا مطمئن هستی ؟",
        text: "در صورت انجام این عملیات قادر به بازگردانی آن نمی باشید.",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "/admin/Report/DeleteReportGroup",
                    type: "post",
                    data: {
                        id: id
                    },
                    beforeSend: function () {

                    },
                    success: function (response) {
                        if (response.status === "error") {
                            swal({
                                title: "خطا",
                                text: response.message,
                                icon: "error",
                                button: "باشه"
                            });
                        }
                        else {
                            $(`#reportGroup-row-${id}`).fadeOut(500);
                            swal({
                                title: "اعلان",
                                text: response.message,
                                icon: "success",
                                button: "باشه"
                            });
                        }
                    },
                    error: function () {
                        swal({
                            title: "خطا",
                            text: "عملیات با خطا مواجه شد لطفا مجدد تلاش کنید .",
                            icon: "error",
                            button: "باشه"
                        });
                    }
                });
            }
        });
}
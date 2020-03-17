var SettingControllerMedia = function () {
    this.Initial = function () {
        handleEvent();
    }

    handleEvent = function () {
        $(document).on('click', '#btnSubmitMedia', function () {
            postMediaForm();
        })
    }

    postMediaForm = function () {
        let validateForm = qhn.Validate('#frmMedia');

        if (validateForm == false) { return false; }

        $.ajax({
            type: 'POST',
            url: '/admin/setting/upload',
            data: $('#frmMedia').serialize(),
            beforeSend: function () {
                qhn.ShowLoading();
            }

        }).done(function (data, textStatus, jqXHR) {
            qhn.PushMessage(data.Level, data.Message, '#show-message');
            qhn.HideLoading();
        }).fail(function (jqXHR, textStatus, error) {
            qhn.HideLoading();
        });

    }
}
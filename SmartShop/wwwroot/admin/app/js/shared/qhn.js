var qhn = {

    Pagination: {
        PAGE_SIZE: 20,
        PAGE_CURRENT: 1,
    },

    LevelConstant: {
        SUCCESS: 1,
        WARNING: 2,
        ERROR: 3,
        INFO: 4,
    },

    RuleValidateConstant: {
        REQUIRED: "required",
        NUMBER: "number",
    },

    ObjectParamModal: {
        footer_btn_right_text: "Save change",
        footer_btn_left_text: "Close",
        footer_class_btn_right: "btn btn-primary",
        footer_class_btn_left: "btn btn-default qhn-close",
        footer_btn_id_right: "btn_modal_save_change",
        footer_btn_id_left: "btn_modal_close",
        footer_is_show_btn_left: true,
        footer_is_show_btn_right: true,
        body_content: "",
        header_title: "",


    },

    ShowLoading: function () {
        $('.loading').css({ 'display': 'block' });
    },

    HideLoading: function () {
        $('.loading').css({ 'display': 'none' });
    },

    PushMessage: function (level, message, element) {
        let classAlert = '';

        if (level == qhn.LevelConstant.SUCCESS) {
            classAlert = 'alert-success';
        } else if (level == qhn.LevelConstant.ERROR) {
            classAlert = 'alert-danger';
        } else if (level == qhn.LevelConstant.WARNING) {
            classAlert = 'alert-warning';
        } else if (level == qhn.LevelConstant.INFO) {
            classAlert = 'alert-info';
        }

        let content = `
                    <div class="alert ${classAlert} alert-dismissible fade in" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                        ${message}
                    </div>
                    `;
        $(element).html(content);
    },

    /**
     * Validate input
     */
    Validate: function (formElement) {

        // reset text error before validate
        $(formElement).find('.qhn-error-danger').text('');

        let listInput = $(formElement).find('.qhn-validate-cus');

        let listErrors = [];

        $.each(listInput, function (key, elementInput) {
            let ruleValidate = $(elementInput).data('validate').split(",");
            for (let i = 0; i < ruleValidate.length; i++) {
                if (ruleValidate[i].trim() == qhn.RuleValidateConstant.REQUIRED) {
                    let check = qhnIsString($(elementInput).val(), $(elementInput).data('name'));
                    if (check != '') {
                        listErrors.push({ key: $(elementInput).data('field'), value: check });
                        break;
                    }
                }
                if (ruleValidate[i].trim() == qhn.RuleValidateConstant.NUMBER) {
                    let check = qhnIsNumber($(elementInput).val(), $(elementInput).data('name'));
                    if (check != '') {
                        listErrors.push({ key: $(elementInput).data('field'), value: check });
                    }
                }
            }
        })

        if (listErrors.length > 0) {
            showMessageValidate(listErrors);
            return false
        }

        return true;
    },

    /**
     * End validate input
     */

    /**
     * 
     * @param {*} url => url post 
     * @param {*} id  => primary key
     * @param {*} callback => function callback
     */
    SweetAlertDelete: function(url, id, callback){
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {

                let objectInfo = {
                    title: 'Deleted!',
                    message: 'Your item has been deleted',
                    icon: 'success'
                };

                $.ajax({
                    type: 'POST',
                    url: url,
                    data: { Id: id },
                    async: false,
                    success: function (response) {
                        if(response.Status == false){
                            objectInfo.title = 'Cancelled!';
                            objectInfo.message = 'Delete item not success, please try again later';
                            objectInfo.icon = 'error';
                        }
                    }
                })
                Swal.fire(
                    objectInfo.title,
                    objectInfo.message,
                    objectInfo.icon
                ).then(function(){
                    if (typeof callback == 'function'){
                        callback();
                    }
                })
            }
        })
    },

    ShowModal: function(){

        let footer_button_left = '';
        let footer_button_right = '';
        if(qhn.ObjectParamModal.footer_is_show_btn_left == true){
            footer_button_left = `<button type="button" class="${qhn.ObjectParamModal.footer_class_btn_left}" data-dismiss="modal" id="${qhn.ObjectParamModal.footer_btn_id_left}">${qhn.ObjectParamModal.footer_btn_left_text}</button>`;
        }
        if(qhn.ObjectParamModal.footer_is_show_btn_right == true){
            footer_button_right = `<button type="button" class="${qhn.ObjectParamModal.footer_class_btn_right}" id="${qhn.ObjectParamModal.footer_btn_id_right}" id="${qhn.ObjectParamModal.footer_btn_id_right}">${qhn.ObjectParamModal.footer_btn_right_text}</button>`;
        }

        let html = `
        <div class="modal fade qhn-modal-lg" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close qhn-close" data-dismiss="modal"><span aria-hidden="true">×</span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel">${qhn.ObjectParamModal.header_title}</h4>
                    </div>
                    <div class="modal-body">
                        ${qhn.ObjectParamModal.body_content}
                    </div>
                    <div class="modal-footer">
                        ${footer_button_left}
                        ${footer_button_right}
                    </div>
                </div>
            </div>
        </div>
        `;

        let modal = $(html);

        modal.modal({backdrop: 'static', keyboard: false}).on('hidden.bs.modal', function (e) {
            modal.remove();
        });

        //return html;
    }
}




$(document).ready(function () {
    qhn.HideLoading();
    $('.right_col').height($('.x_content').height());
})


// validate string
function qhnIsString(str, name)
{
    if(str.search(/[\w\w]/) < 0)
    {
        return name + " can not be blank";
    }
    return "";
}

function qhnIsNumber(str, name)
{
    if(str.search(/[0-9]+/) < 0)
    {
        return name + " must is numeric";
    }
    return "";
}

function showMessageValidate(errors)
{
    $.each(errors, function(key, value){
        $('#'+value.key).text(value.value);
    })
}
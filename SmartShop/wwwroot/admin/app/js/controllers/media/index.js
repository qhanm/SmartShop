var MediaControlerIndex = function () {

    this.Initial = function () {
        LoadData();
        RegisterEvent();
    }

    RegisterEvent = function () {
        // on change input search
        $(document).on('change', '#qhn-search', function () {
            LoadData($('#qhn-search').val(), 20, 1);
        })

        // on change select paginate limit on site
        $(document).on('change', '#qhn-select', function () {
            LoadData($('#qhn-search').val(), $('#qhn-select').val(), 1);
        })

        // on click change page current
        $(document).on('click', '#qhn-pagination li', function () {
            LoadData($('#qhn-search').val(), $('#qhn-select').val(), $(this).data('paginate'));
        })

        // on click delete item
        $(document).on('click', '.qhn-popup-sweetalert-delete', function (event) {
            event.preventDefault();
            qhn.SweetAlertDelete($(this).data('url'), $(this).data('id'), function(){
                LoadData($('#qhn-search').val(), $('#qhn-select').val(), $('#qhn-pagination').find('.active').data('paginate'))
            });
        })

        // show modal edit file
        $(document).on('click', '.qhn-popup-modal-edit', function(event){
            event.preventDefault();

            let contentData = $(this).data('content');

            let content = `
                        <div class="row">
                            <div class=col-md-5 style="width:250px;">
                                <img style="margin-left:30px;" src="${contentData.Url}" width="100%" height="100%" >
                            </div>
                            <div class="col-md-7">
                                <div  style="margin-left:30px;" class="col-md-12" id="show-message"></div>
                                <form id="frmMedia" data-parsley-validate="" class="form-horizontal form-label-left" novalidate="">
                                    <input type="hidden" value="${contentData.Id}" name="Id" />
                                    <input type="hidden" value="${contentData.Url}" name="Url" />
                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3 col-sm-offset-3">
                                
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                            File Name
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" data-name="File name" data-field="File_Name"
                                                data-validate="required" value="${contentData.Name == null ? "" : contentData.Name}" name="Name" required="required"
                                                class="form-control col-md-7 col-xs-12 qhn-validate-cus">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Alt">
                                            Alt
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" data-name="Alt" data-field="Alt" value="${contentData.Alt == null ? "" : contentData.Alt}" name="Alt"
                                                class="form-control col-md-7 col-xs-12 qhn-validate-cus">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Description">
                                            Description
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <input type="text" data-name="Description" data-field="Description" value="${contentData.Description == null ? "" : contentData.Description}" name="Description"
                                                class="form-control col-md-7 col-xs-12 qhn-validate-cus">
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="Description">
                                            Link
                                        </label>
                                        <div class="col-md-9 col-sm-9 col-xs-12">
                                            <label><a href="${contentData.Url}" style="word-wrap: break-word;">${contentData.Url}</a></label>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                        `;
            qhn.ObjectParamModal.header_title = 'Media | Edit Image';
            qhn.ObjectParamModal.body_content = content;
            qhn.ShowModal();
        })

        // on click save change file edit
        $(document).on('click', '#btn_modal_save_change', function(event){
            event.preventDefault();

            $.ajax({
                type: 'POST',
                url: '/admin/media/update-file',
                data: $('#frmMedia').serialize(),
                beforeSend: function(){
                    qhn.ShowLoading();
                }
            }).done(function(data, textStatus, jqXHR){
                qhn.PushMessage(data.Level, data.Message, '#show-message');
                qhn.HideLoading();
            }).fail(function(jqXHR, textStatus, error){
                qhn.HideLoading();
            });
        })


        // on click close modal reload page content
        $(document).on('click', '.qhn-close', function () {
            console.log('call');
            LoadData($('#qhn-search').val(), $('#qhn-select').val(), $('#qhn-pagination').find('.active').data('paginate'))
        })
    }

    LoadData = function (search = '', pageSize = 20, pageCurrent = 1) {
        $.ajax({
            type: 'GET',
            url: '/admin/media/index-get-all?search=' + search + '&pageSize=' + pageSize + '&pageCurrent=' + pageCurrent,
            beforeSend: function () {
                qhn.ShowLoading();
            }
        }).done(function (data, textStatus, jqXHR) {
            let content = '';
            $.each(data.Data.Results, function (key, value) {
                content += `
                        <div class="col-md-55">
                            <div class="thumbnail">
                                <div class="image view view-first qhn-thumbnail-image-custom">
                                    <img style="width: 100%; display: block;" src="${value.Url}" alt="${value.Alt}">
                                    <div class="mask no-caption">
                                        <div class="tools tools-bottom">
                                            <a href="#"><i class="fa fa-link"></i></a>
                                            <a href="#" class="qhn-popup-modal-edit" data-content='${JSON.stringify(value)}'><i class="fa fa-pencil"></i></a>
                                            <a href="#" class="qhn-popup-sweetalert-delete" data-url="/admin/media/delete-file" data-id="${value.Id}"><i class="fa fa-times"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="caption">
                                    <p>
                                        <strong>${value.Name}</strong>
                                    </p>
                                    
                                </div>
                            </div>
                        </div>
                        `;
            })

            $('#qhn-content').html(content);

            if(data.Data.PageCount > 1)
            {
                $('#qhn-pagination').html(QHN_Pagiante.ShowPageContent(data.Data.Link));
            } else{
                $('#qhn-pagination').html('');
            }

            $('#qhn-show-entry').text(QHN_Pagiante.ShowTextEntry(data.Data.PageCurrent, data.Data.PageSize, data.Data.TotalRecord));
            console.log(data);
            qhn.HideLoading();
        }).fail(function (jqXHR, textStatus, error) {
            console.log(error);
            qhn.HideLoading();
        });
    }
}

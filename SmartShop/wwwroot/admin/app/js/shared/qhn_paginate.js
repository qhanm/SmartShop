var QHN_Pagiante = {


    /**
     * pageObject = { PageStart, PageEnd, PageLast, PageNext }
     */
    ShowPageContent: function(pageObject){

        let content = '<ul class="pagination pull-right qhn-pagination qhn-pagination-custom" id="qhn-pagination">';

        content += '<li data-paginate="1"><a href="#"><i class="fa fa-angle-double-left"></i></a></li>';
        content += '<li data-paginate="'+pageObject.PageLast+'"><a href="#"><i class="fa fa-angle-left"></i></a></li>';

        for(let i = pageObject.PageStart; i <= pageObject.PageEnd; i++)
        {
            if(i == pageObject.PageCurrent)
            {
                content += '<li class="active" data-paginate="'+i+'"><a href="#">'+i+'</a></li>';
            }else{
                content += '<li data-paginate="'+i+'"><a href="#">'+i+'</a></li>';
            }
        }
        content += '<li data-paginate="'+pageObject.PageNext+'"><a href="#"><i class="fa fa-angle-right"></i></a></li>';
        content += '<li data-paginate="'+pageObject.PageCount+'"><a href="#"><i class="fa fa-angle-double-right"></i></a></li>';
        content += '</ul>';
        return content;
    },

    ShowTextEntry: function (pageCurrent, pageSize, totalRecord) {
        let startEntry = ((pageCurrent - 1) * pageSize) + 1;
        let endEntry = pageSize * pageCurrent;
        if (endEntry > totalRecord) {
            endEntry = totalRecord;
        }

        if(totalRecord == 0)
        {
            startEntry = totalRecord;
        }

        return 'Showing ' + startEntry + ' to ' + endEntry + ' of ' + totalRecord + ' entries';
    }
}
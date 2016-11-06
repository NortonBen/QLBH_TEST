function get_data_media(data, el) {
    console.log("run");
    var _el = $(`input[img='${el}']`);
    __el = _el;
    var url = data.url;
    _el.val(url);
    $.modal.close();
}

function open_get_data_media(_el) {
    var el = $("#modal-select-media");
    var iframe = el.find("iframe");
    var url = iframe.attr("data-src");
    iframe.attr("src",`${url}?el=${_el}`);
    el.modal();
}
$(document).ready(function () {

    //易房弹层	
    $("a[rel]").overlay({ mask: '#000' });


    //易房表单提交数据验证 
    jQuery.tools.validator.fn("[validType=integer]", "请填写整数", function (input, value) {
        return /^\d+$/.test(value);
    });
    jQuery.tools.validator.fn("[validType=float]", "请填写浮点数", function (input, value) {
        return /^\d+\.\d{1,2}$/.test(value);
    });

    jQuery.tools.validator.fn("[validType=decimal]", "请填写浮点或整数", function (input, value) {
        return /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/.test(value);
    });

    jQuery.tools.validator.fn("[validType=mobile]", "请填写11位手机号码", function (input, value) {
        return /^((\(\d{2,3}\))|(\d{3}\-))?(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1}))+\d{8})$/.test(value);
    });
    jQuery.tools.validator.fn("[validType=email]", "请正确填写您的Email", function (input, value) {
        return /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/.test(value);
    });
    jQuery.tools.validator.fn("select[required]", "请选择一项", function (input, value) {
        return (value != "#") ? true : false;
    });
    jQuery.tools.validator.localize("en", {
        ':number': '此项必须为数字',
        '[max]': '数值不能大于$1',
        '[min]': '数值不能小于$1',
        '[required]': '请填写此字段'
    });

    $("#cgstateform").validator({
        position: 'top left',
        offset: [-12, 0],
        singleError: true,
        message: '<div><em/></div>',
        onFail: function (e, errors) {
            jQuery.each(errors, function () {
                var input = this.input;
                input.focus();
                input.css({ border: '#ECC25E solid 1px' }).blur(function () {
                    input.css({ border: '#cccccc solid 1px' });
                    var msg = input.data('msg.el');
                    if (msg) {
                        msg.css({ visibility: 'hidden' });
                    };
                });
            });
        }
    });

});


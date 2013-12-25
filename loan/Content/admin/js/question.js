
var Question = function () {


    var questionInit = function () {
       
        // for more info visit the official plugin documentation: 
        // http://docs.jquery.com/Plugins/Validation

        $("#form_question").validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: false, // do not focus the last invalid input
            ignore: "",
            rules: {
                title: {
                    minlength: 2,
                    required: true
                },
                content: {
                    
                    required: true

                }
            },
            messages: {

                title: {
                    required: "请输入新闻标题",
                    minlength:"标题长点，好吧"

                },
                content: {
                    required: "请输入文章内容",

                }
            },




            highlight: function (element) { // hightlight error inputs
                $(element)
                    .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            unhighlight: function (element) { // revert the change done by hightlight
                $(element)
                    .closest('.form-group').removeClass('has-error'); // set error class to the control group
            },

            success: function (label) {
                label
                    .closest('.form-group').removeClass('has-error'); // set success class to the control group
            }


        });
    }



    return {
        init: function () {
            questionInit();
        }
    }

}()
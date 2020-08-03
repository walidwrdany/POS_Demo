var arrows;
if (KTUtil.isRTL()) {
    arrows = {
        leftArrow: '<i class="la la-angle-right"></i>',
        rightArrow: '<i class="la la-angle-left"></i>'
    }
} else {
    arrows = {
        leftArrow: '<i class="la la-angle-left"></i>',
        rightArrow: '<i class="la la-angle-right"></i>'
    }
}

$('select.select2').select2();
$('.inputmask_3').inputmask('9{0,3}');
$('.inputmask_11').inputmask({ "mask": "9{10,11}", 'autoUnmask': true, 'removeMaskOnSubmit': true, 'greedy': false });
$('.inputmask_GO_11').inputmask({ "mask": "99999999999", 'autoUnmask': true, 'removeMaskOnSubmit': true, 'greedy': false });

$('input.datepicker').datepicker({
    rtl: KTUtil.isRTL(),
    todayHighlight: true,
    autoclose: true,
    format: 'dd-MM-yyyy',
    orientation: "bottom left",
    templates: arrows
});

$('.datepicker').datepicker()
    .on('changeDate', function (e) {
        // `e` here contains the extra attributes
        console.log($(e.target).val());
    });

$('.kt_maxlength').maxlength({
    alwaysShow: true,
    threshold: 5,
    placement: 'top-left',
    warningClass: "kt-badge kt-badge--warning kt-badge--rounded kt-badge--inline",
    limitReachedClass: "kt-badge kt-badge--success kt-badge--rounded kt-badge--inline"
});


jQuery(document).ready(function () {

    $('a[href="#"]').removeAttr('href');



    $('input, select, textarea').each(function () {
        //to add placeholder for all input that not have placeholder from label
        var $InputEl = $(this);
        var placeholder = $InputEl.attr('placeholder');
        var required = $InputEl.attr('data-val-required');
        var disabled = $InputEl.attr('disabled');
        if ((typeof placeholder === typeof undefined || placeholder === false) && (typeof disabled === typeof undefined || disabled === false)) {
            $InputEl.attr('placeholder', $($InputEl.parents('div.form-group').find('label[for="' + $InputEl.attr('id') + '"]')).text());
        }

        //if (!(typeof required === typeof undefined || required === false)) {
        //    alert($InputEl.attr('id'));
        //}
    });

});


// https://stackoverflow.com/a/16025232
$.fn.clearValidation = function () { var v = $(this).validate(); $('[name]', this).each(function () { v.successList.push(this); v.showErrors(); }); v.resetForm(); v.reset(); };

$.fn.clearFormElements = function () { var f = $(this); f.find(':input').each(function () { switch (this.type) { case 'password': case 'text': case 'textarea': case 'file': case 'select-one': $(this).val('').trigger('change'); break; case 'select-multiple': $(this).val('').trigger('change'); break; case 'date': case 'number': case 'tel': case 'email': $(this).val(''); break; case 'checkbox': this.checked = false; $(this).removeAttr('checked').iCheck('update'); var classes = $(this).parent().closest('div'); $(classes).removeClass('checked '); break; case 'radio': this.checked = false; $(this).iCheck('uncheck').iCheck('update'); break; } }); }


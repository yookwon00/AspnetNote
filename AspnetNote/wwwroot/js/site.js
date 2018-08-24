
// Write your JavaScript code.
$(".editor").trumbowyg({
    btnsDef: {
        myImage: {
            dropdown: ['insertImage', 'upload'],
            ico:'insertImage'
        }
    },
    btns: [
        ['viewHTML'],
        ['formatting'],
        ['superscript', 'subscript'],
        ['link'],
        ['insertImage'],
        'myImage',
        'btnGrp-justify',
        'btnGrp-list',
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']
    ]
});
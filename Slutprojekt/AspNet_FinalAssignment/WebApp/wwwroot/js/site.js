document.addEventListener("DOMContentLoaded", () => {
    let btnMenu = document.querySelector('.btn-menu')
    let nav = document.querySelector('nav')

    btnMenu.addEventListener('click', () => {
        btnMenu.classList.toggle('active')
        btnMenu.classList.toggle('fixed')

        nav.classList.toggle('active')
    })

    window.addEventListener('resize', () => {
        btnMenu.classList.remove('active')
        btnMenu.classList.remove('fixed')

        nav.classList.remove('active')
    })
})

/*----------------------------------------------------*/
//SignUP

let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {
        input.addEventListener('keyup', (e) => {
            switch (e.target.type) {
                case 'text':
                    textValidation(e, e.target.dataset.valMinlengthMin)
                    break

                case 'email':
                    emailValidation(e)
                    break

                case 'password':
                    passwordValidation(e)
                    break
            }
        })
    }
})

const handleValidationOutput = (isValid, e, text = "") => {
    let span = document.querySelector(`[data-valmsg-for="${e.target.name}"]`)

    if (isValid) {
        e.target.classList.remove('input-validation-error')
        span.classList.remove('field-validation-error')
        span.classList.add('field-validation-valid')
        span.innerHTML = ""

    } else {
        e.target.classList.add('input-validation-error')
        span.classList.add('field-validation-error')
        span.classList.remove('field-validation-valid')
        span.innerHTML = text
    }
}

const textValidation = (e, minLength = 1) => {
    if (e.target.value.length > 0)
        handleValidationOutput(e.target.value.length >= minLength, e, e.target.dataset.valMinlength)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}

const emailValidation = (e) => {
    const regEx = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/

    if (e.target.value.length > 0)
        handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}

const passwordValidation = (e) => {
    const regEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$/


    let compareTo = document.querySelector(e.target.dataset.valEqualtoOther)

    if (e.target.value.length > 0)
        handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}

/*----------------------------------------------------*/

document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()

})

function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector('#fileUploader')
        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }

    }
    catch { }
}

/*----------------------------------------------------*/
document.addEventListener('DOMContentLoaded', function () {
    select();
    search();
});
function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')

                updateCoursesByFilter(category)
            })
        })

    }
    catch { }
}

function search() {
    try {

        document.querySelector('#searchQuery').addEventListener('keyup', function () {
            const searchValue = this.value
            const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
            const url = `/courses/courses?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

            fetch(url)
                .then(res => res.text())
                .then(data => {
                    const parser = new DOMParser()
                    const dom = parser.parseFromString(data, 'text/html')
                    document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

                    const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
                    document.querySelector('.pagination').innerHTML = pagination

                })
        })

    }
    catch { }
}


function updateCoursesByFilter(category) {
    const searchValue = document.getElementById('searchQuery').value
    const url = `/courses/courses?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

            const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
            document.querySelector('.pagination').innerHTML = pagination

        })
}
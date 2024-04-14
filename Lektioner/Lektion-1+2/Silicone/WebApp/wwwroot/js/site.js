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
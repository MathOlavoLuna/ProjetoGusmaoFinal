const NavBarButtons = document.getElementsByClassName('navbar-option');
const NavBarTitle = document.getElementById('navbar-title');

window.addEventListener('scroll', () => {
    for (var i = 0; i < NavBarButtons.length; i++) {
        const Btn = NavBarButtons[i]
        if (window.scrollY > 350) {
            NavBarTitle.classList.add('navbar-title-scrollY');
            Btn.classList.add('navbar-option-scrollY');
        } else if (window.scrollY < 350) {
            Btn.classList.remove('navbar-option-scrollY');
            NavBarTitle.classList.remove('navbar-title-scrollY');
        }
    }
})


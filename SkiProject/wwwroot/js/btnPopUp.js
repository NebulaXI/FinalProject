
const slope = document.querySelector('.slope');
const overlay = document.querySelector('.overlay');
const btnCloseModal = document.querySelector('.close-modal');
const btnOpenModal = document.querySelector('.show-modal');

const closeModal = function () {
    slope.classList.add('hidden');
    overlay.classList.add('hidden');
};
const openModal = function () {
    console.log(`In`);
    slope.classList.remove('hidden');
    overlay.classList.remove('hidden');
};


btnOpenModal.addEventListener('click', openModal);

btnCloseModal.addEventListener('click',closeModal);
overlay.addEventListener('click', closeModal);

//document.addEventListener('keydown', function (e) {
//    if (e.key === 'Escape' && !slope.classList.contains('hidden')) {
//        closeModal();
//    }
//        console.log('ok');
//});
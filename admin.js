const hiddenBlock = document.querySelector('.hidden-wrapper')
const showBtn = document.querySelector('.show-all')
const hideBtn = document.querySelector('.hide-all')

const toggleShow = (block) => {
     block.classList.toggle('visible')
}

const showListener = () => {
    hideBtn.addEventListener('click', hideListener)
    toggleShow(hiddenBlock)
    hideBtn.classList.toggle('visible')
    showBtn.classList.toggle('unvisible')
    showBtn.removeEventListener('click', showListener)
}
const hideListener = () => {
    showBtn.addEventListener('click', showListener)
    hideBtn.classList.toggle('visible')
    showBtn.classList.toggle('unvisible')
    toggleShow(hiddenBlock)
    hideBtn.removeEventListener('click', hideListener)
}

showBtn.addEventListener('click', showListener)
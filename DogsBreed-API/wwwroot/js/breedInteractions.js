// Card hover animations
document.querySelectorAll('.breed-card').forEach(card => {
    card.addEventListener('mouseenter', function () {
        this.querySelector('i.fa-dog, i.fa-paw')?.classList.add('fa-bounce');
    });
    card.addEventListener('mouseleave', function () {
        this.querySelector('i.fa-dog, i.fa-paw')?.classList.remove('fa-bounce');
    });
});
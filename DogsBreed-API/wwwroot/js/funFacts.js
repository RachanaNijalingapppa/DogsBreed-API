// Random dog facts to display
const dogFacts = [
    "Dogs have three eyelids! The third helps keep their eyes moist.",
    "A dog's nose print is unique, like a human fingerprint!",
    "The Basenji is the only dog that doesn't bark!",
    "Dogs can smell your feelings! They detect chemical changes in your sweat.",
    "The Norwegian Lundehund has six toes on each foot!",
    "Dogs dream just like humans do! Watch those paws twitch!",
    "A Bloodhound's sense of smell can be used as evidence in court!",
    "Dogs have 18 muscles controlling their ears!",
    "The world's oldest dog lived to be 29 years old!",
    "Dogs can learn over 100 words and gestures!"
];

document.getElementById('funFactBtn').addEventListener('click', function () {
    const factDisplay = document.getElementById('funFactDisplay');
    factDisplay.textContent = dogFacts[Math.floor(Math.random() * dogFacts.length)];
    factDisplay.classList.remove('d-none');

    setTimeout(() => {
        factDisplay.classList.add('fade-out');
        setTimeout(() => {
            factDisplay.classList.add('d-none');
            factDisplay.classList.remove('fade-out');
        }, 1000);
    }, 5000);
});

// Add wag effect on hover
document.querySelectorAll('.breed-card').forEach(card => {
    card.addEventListener('mouseenter', function () {
        this.querySelector('i.fa-dog, i.fa-paw')?.classList.add('fa-bounce');
    });
    card.addEventListener('mouseleave', function () {
        this.querySelector('i.fa-dog, i.fa-paw')?.classList.remove('fa-bounce');
    });
});
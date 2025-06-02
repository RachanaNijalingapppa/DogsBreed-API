document.addEventListener('DOMContentLoaded', function () {
    const container = document.getElementById('subBreedsContainer');
    const addButton = document.getElementById('addSubBreed');

    if (addButton && container) {
        let subBreedCount = container.children.length;

        addButton.addEventListener('click', function () {
            const div = document.createElement('div');
            div.className = 'input-group mb-2';
            div.innerHTML = `
                <input name="SubBreeds[${subBreedCount}]" class="form-control" />
                <button type="button" class="btn btn-outline-danger remove-subbreed">
                    <i class="fas fa-times"></i>
                </button>
            `;
            container.appendChild(div);
            subBreedCount++;
        });

        container.addEventListener('click', function (e) {
            if (e.target.classList.contains('remove-subbreed')) {
                e.target.closest('.input-group').remove();
                // Re-index remaining sub-breeds
                const inputs = container.querySelectorAll('input[name^="SubBreeds"]');
                inputs.forEach((input, index) => {
                    input.name = `SubBreeds[${index}]`;
                });
                subBreedCount = inputs.length;
            }
        });
    }
});
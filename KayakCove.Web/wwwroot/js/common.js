function showConfirmModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmModal')).show();
}

function hideConfirmModal() {
    bootstrap.Modal.getOrCreateInstance(document.getElementById('confirmModal')).hide();
}
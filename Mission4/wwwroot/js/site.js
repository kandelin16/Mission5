// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function deleteMovie(movieID, movName) {
    document.getElementById("movieID").value = movieID
    if (confirm("Are you sure you would like to delete " + movName + "? This is irreversible.")) {
        document.getElementById("deleteForm").submit()
    }
}
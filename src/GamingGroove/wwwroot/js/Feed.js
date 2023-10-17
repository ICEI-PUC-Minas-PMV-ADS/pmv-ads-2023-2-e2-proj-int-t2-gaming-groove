<script>
    $(document).ready(function () {
        // Carregar o conteúdo da View de criação de publicações via AJAX
        $('#staticBackdrop').on('show.bs.modal', function () {
            $.ajax({
                url: '@Url.Action("Create", "Publicacao")',
                type: 'GET',
                success: function (data) {
                    $('#createPublicacaoContent').html(data);
                }
            });
        });
        });
</script>
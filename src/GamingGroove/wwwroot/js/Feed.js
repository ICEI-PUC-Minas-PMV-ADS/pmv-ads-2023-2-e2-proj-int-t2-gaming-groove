<script>
    $(document).ready(function () {
        // Carregar o conte�do da View de cria��o de publica��es via AJAX
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
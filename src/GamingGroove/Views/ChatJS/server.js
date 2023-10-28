const express = require('express');
const http = require('http');
const socketIo = require('socket.io');

const app = express();
const server = http.createServer(app);
const io = socketIo(server);

const mysql = require('mysql2/promise');

const dbConfig = {
    host: 'localhost',
    user: 'user',
    password: 'userpassword',
    database: 'gaminggroove'
};

let connection;

async function initDb() {
    connection = await mysql.createConnection(dbConfig);
    console.log("Conexão com o banco de dados estabelecida.");
}

initDb();


app.use(express.static('public'));

io.on('connection', async (socket) => {
    console.log('Novo usuário conectado');
    const [rows] = await connection.execute('SELECT historico FROM Chats ORDER BY chatId DESC LIMIT 50');
    for (let row of rows.reverse()) {
        socket.emit('receiveMessage', row.historico);
    }

    socket.on('sendMessage', async (message) => {
        io.emit('receiveMessage', message);
        // Insere a mensagem no banco de dados
        try {
            const colunas = ["chatId",
                "equipeId",
                "amizadeId",
                "historico"]

            const valores = [rows.length + 1 , 1, 1, `'${message}'`]

            await connection.execute(`INSERT INTO Chats (${colunas})
                                      VALUES (${valores})`);
        } catch (error) {
            console.error("Erro ao inserir mensagem no banco de dados:", error);
        }
    });

    socket.on('disconnect', () => {
        console.log('Usuário desconectou');
    });
});

const PORT = 3000;
server.listen(PORT, () => {
    console.log(`Servidor rodando na porta ${PORT}`);
});

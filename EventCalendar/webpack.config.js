const path = require('path');

module.exports = {
    entry: './assets/event-calendar.js',
    output: {
        filename: 'event-calendar.js',
        path: path.resolve(__dirname, '../wwwroot/Scripts'),
    },
    module: {
        rules: [
            {
                test: /\.css$/i,
                use: ['style-loader', 'css-loader'],
            },
        ]
    },
    mode: 'development',
    watch: true
}

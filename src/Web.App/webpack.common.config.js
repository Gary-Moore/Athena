const path = require('path');
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');

module.exports = {
    entry: {
        app: './app/main.ts'
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: '[name].bundle.js',
        publicPath: '/dist/'
    },
    resolve: {
        extensions: [".ts", ".tsx", ".js"]
    },
    plugins: [
        new ForkTsCheckerWebpackPlugin()
    ],
    module: {
        rules:[
            {
                test: /\.m?js$/,
                exclude: /(node_modules|bower_components)/,
                use:{
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/preset-env']
                    }
                }
                
            }
        ]
    }
}
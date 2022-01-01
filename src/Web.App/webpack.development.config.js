const { merge } = require('webpack-merge');
const common = require('./webpack.common.config');

module.exports = merge(common, {
    mode: 'development',
    devtool: 'inline-source-map',
    module: {
        rules:[
            {
                test: /\.ts?$/,
                exclude: /node_modules/,
                use:[
                    {
                        loader: 'babel-loader'                    
                    },
                    {
                        loader: 'ts-loader',
                        options: {
                            transpileOnly: true,
                            experimentalWatchApi: true,
                        }
                    }
                ]                
            },
            {
                test: /\.(s*)css$/,
                use:[
                    {
                        // inject CSS to page
                        loader: 'style-loader'
                    },
                    {
                        // translates CSS into CommonJS modules
                        loader: 'css-loader'
                    },
                    {
                        loader: 'sass-loader'
                    }
                ]
            }
        ]
    }
});

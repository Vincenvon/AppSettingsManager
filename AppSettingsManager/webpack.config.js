const path = require('path');
const webpack = require('webpack');

const productionMode = process.env.NODE_ENV === 'production';

module.exports = {
    devtool: productionMode ? false : 'source-map',
    mode: productionMode ? 'production' : 'development',
    entry: {
        application: ['@babel/polyfill', './src/index.js'],
    },
    output: {
        path: path.join(__dirname, '/AppSettingsManagerContent/js/'),
        filename: '[name].js',
    },
    resolve: {
        alias: {
            root: path.resolve(__dirname, './src'),
        },
        extensions: ['.web.js', '.mjs', '.js', '.json', '.web.jsx', '.jsx'],
        modules: [path.resolve('node_modules'), 'node_modules'],
    },
    plugins: [
        new webpack.DefinePlugin({
            'process.env': {
                // This has effect on the react lib size
                NODE_ENV: JSON.stringify('development'),
            },
        }),
        new webpack.ExtendedAPIPlugin(),
    ],
    optimization: {
        minimize: false,
    },
    module: {
        rules: [
            {
                exclude: /node_modules/,
                include: [
                    path.resolve(__dirname, 'src'),

                ],
                loader: 'babel-loader',
                query: {
                    presets: ['@babel/preset-env', '@babel/preset-react'],
                    plugins: ['@babel/plugin-syntax-dynamic-import', '@babel/plugin-proposal-class-properties'],
                },
            },
            {
                test: /\.less$/,
                use: ['style-loader', 'css-loader', 'less-loader'],
            },
            {
                test: /\.(gif|png|jpe?g|svg)$/i,
                use: [
                    'file-loader',
                    {
                        loader: 'image-webpack-loader',
                        options: {
                            bypassOnDebug: true, // webpack@1.x
                            disable: true, // webpack@2.x and newer
                        },
                    },
                ],
            },
        ],
    },
};

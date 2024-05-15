const path = require('path')
const { CleanWebpackPlugin } = require('clean-webpack-plugin')
const webpack = require('webpack')
const dotenv = require('dotenv')


module.exports = {
  mode: 'development',
  entry: './src/main/index.tsx',
  output: {
    path: path.join(__dirname, 'build/js'),
    publicPath: '/build/js',
    filename: 'bundle.js'
  },
  resolve: {
    extensions: ['.ts', '.tsx', '.js', '.scss'],
    alias: {
      '@': path.join(__dirname, 'src')
    }
  },
  module: {
    rules: [
      {
        test: /\.svg$/,
        loader: 'svg-inline-loader'
      },
      {
        test: /\.ts(x?)$/,
        loader: 'ts-loader',
        exclude: /node-modules/
      },
      {
        test: /\.scss$/,
        use: [
          {
            loader: 'style-loader'
          },
          {
            loader: 'css-loader',
            options: {
              modules: true
            }
          },
          {
            loader: 'sass-loader'
          }
        ]
      }
    ]
  },
  devServer: {
    devMiddleware: {
      writeToDisk: true
    },
    static: {
      directory: './build'
    },
    historyApiFallback: true
  },
  // externals: {
  //   'react': 'React',
  //   'react-dom': 'ReactDOM'
  // },
  plugins: [
    new webpack.DefinePlugin({
      'process.env': JSON.stringify(process.env)
    }),
    new CleanWebpackPlugin(),
    new webpack.ProvidePlugin({
      React: 'react',
    }),
  ],
}
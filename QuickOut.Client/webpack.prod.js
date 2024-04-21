import HtmlWebpackPlugin from 'html-webpack-plugin'
import MiniCssExtractPlugin from 'mini-css-extract-plugin'
import webpack from 'webpack'
import { merge } from 'webpack-merge'
import common from './webpack.common'

export default merge(common, {
  mode: 'production',
  module: {
    rules: [{
      test: /\.ts(x?)$/,
      loader: 'ts-loader'
    }, {
      test: /\.css$/,
      use: [{
        loader: 'style-loader'
      }, {
        loader: 'css-loader'
      }]
    }]
  },
  plugins: [
    new HtmlWebpackPlugin({
      template: './index.prod.html',
    }),
    new MiniCssExtractPlugin({
      filename: 'main-bundle.css',
    }),
    new webpack.ProvidePlugin({
      React: 'react',
    })
  ],
});

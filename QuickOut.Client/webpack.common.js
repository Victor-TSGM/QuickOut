import path from 'path'
import webpack from 'webpack'
import dotenv from 'dotenv'
const __dirname = import.meta.dirname;

// this will update the process.env with environment variables in .env file
dotenv.config()

export default {
  entry: './src/main/index.tsx',
  output: {
    path: path.join(__dirname, 'dist'),
    filename: 'main-bundle-[hash].js',
    publicPath: '/'
  },
  resolve: {
    fallback: {
      "util": false,
      "stream": false,
      "path": false,
      "http": false,
      "https": false,
      "assert": false,
      "tty": false,
      "os": false,
      "zlib": false,
      "url": false,
      "fs": false,
    },
    extensions: ['.ts', '.tsx', '.js'],
    alias: {
      '@': path.join(__dirname, 'src')
    }
  },
  plugins: [
    new webpack.DefinePlugin({
      'process.env': JSON.stringify(process.env)
    })
  ]
}

const colors = require('tailwindcss/colors');

module.exports = {
    purge: {
        enabled: true,
        content: [
            './**/*.html',
            './**/*.razor'
        ],
    },
    darkMode: true,
    theme: [],
    variants: {
        extend: {},
    },
    plugins: [],
}
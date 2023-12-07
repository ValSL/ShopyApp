import { CSSVariablesResolver, MantineColorsTuple, createTheme } from "@mantine/core";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });

const myColors: MantineColorsTuple = [
	"#e5f4ff",
	"#d1e3ff",
	"#a2c5f9",
	"#71a4f3",
	"#4789ee",
	"#2c78eb",
	"#196feb",
	"#075ed1",
	"#0053bd",
	"#0048a7",
];

const blacklight: MantineColorsTuple = [
	'#f4f4fa',
	'#e6e6e9',
	'#cbcbcd',
	'#adadb2',
	'#95959b',
	'#85858d',
	'#7d7d88',
	'#6b6b76',
	'#5f5f6a',
	'#515260'
  ];

export const theme = createTheme({
	fontFamily: inter.style.fontFamily,
	primaryColor: "shopy-blue",
	colors: {
		"shopy-blue": myColors,
		"blacklight": blacklight,
	},
});

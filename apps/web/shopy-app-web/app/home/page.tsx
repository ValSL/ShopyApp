import { Box, SimpleGrid, Container } from "@mantine/core";
import React from "react";
import Header from "../components/Header";
import Filter from "./components/Filter";

const Home = () => {
	return (
		<SimpleGrid cols={4} px="3rem" >
			<Box><Filter/></Box>
			<div>2</div>
			<div>3</div>
			<div>4</div>
		</SimpleGrid>
	);
};

export default Home;

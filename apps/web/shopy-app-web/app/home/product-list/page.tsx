'use client';

import { Box, SimpleGrid, TextInput, Text, CardSection, Image, Flex, Card, Button } from "@mantine/core";
import React from "react";
import Filter from "./components/Filter";
import classes from "./home.module.css";
import { IconSearch } from "@tabler/icons-react";
import { useMediaQuery } from '@mantine/hooks';

const Cardd = () => {
	return (
		<Card p={0} className={classes.card} >
			<CardSection>
				<Image
					height={160}
					src="https://firebasestorage.googleapis.com/v0/b/myshopyapp.appspot.com/o/images%2Fflowers.jpeg07b092a3-964f-41fc-bfa3-b03d1f0f0ad8?alt=media&token=e533d6f2-acdb-41da-acda-22c96533fcf6"
					alt="Norway"
				/>
			</CardSection>
			<Flex p={15} direction="column" gap="12px">
				<Text fw="bold" size="20px">
					Title
				</Text>
				<Flex justify="space-between">
					<Text size="14px" c="#A3A3A3">
						Price:
					</Text>
					<Text fw="bold" size="20px">
						$123
					</Text>
				</Flex>
				<Button>Add to Cart</Button>
			</Flex>
		</Card>
	);
};

// TODO: Сделать адаптив, отдельный грид для списка 
const ProductList = () => {
	const matches = useMediaQuery('(min-width: 55rem)');

	return (
		<>
			{matches ?
				<SimpleGrid cols={4} px="3rem" spacing={30}>
					<Box className={classes.filter}>
						<Filter />
					</Box>
					<Box className={classes.searchInput}>
						<TextInput leftSection={<IconSearch size={16} />} radius="8px" placeholder="Type to search..." />
					</Box>
					<Box>
						<Text fw="bold">12 Results</Text>
					</Box>
					<Box style={{ justifySelf: "end", gridColumn: "3 / span 2" }}>
						<Text>Sort by newest</Text>
					</Box>
					<Box style={{ justifySelf: "start", gridColumn: "2 / span 3" }}>
						<Text>400 - 500</Text>
					</Box>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
				</SimpleGrid>
				:
				<SimpleGrid cols={1} px="3rem" >
					<Box>
						<TextInput leftSection={<IconSearch size={16} />} radius="8px" placeholder="Type to search..." />
					</Box>
					<Filter />
					<Box>
						<Text fw="bold">12 Results</Text>
					</Box>
					<Box>
						<Text>Sort by newest</Text>
					</Box>
					<Box >
						<Text>400 - 500</Text>
					</Box>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
					<div>
						<Cardd />
					</div>
				</SimpleGrid>
			}
		</>
	);
};

export default ProductList;

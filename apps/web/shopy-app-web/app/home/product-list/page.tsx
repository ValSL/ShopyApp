'use client';

import { Box, SimpleGrid, TextInput, Text, CardSection, Image, Flex, Card, Button } from "@mantine/core";
import React from "react";
import Filter from "./components/Filter";
import classes from "./home.module.css";
import { IconSearch } from "@tabler/icons-react";
import { useMediaQuery } from '@mantine/hooks';
import { useGetAllProducts } from "./api/productListApi";
import { ProductCard } from "./components/ProductItem";



const ProductList = () => {
	const matches = useMediaQuery('(min-width: 55rem)');
	const { data: products, isLoading, isError } = useGetAllProducts();

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
					{
						products?.map((product) => {
							return (
								<div key={product.productId}>
									<ProductCard product={product} />
								</div>
							);
						})
					}
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
					{
						products?.map((product) => {
							return (
								<div key={product.productId}>
									<ProductCard product={product} />
								</div>
							);
						})
					}
				</SimpleGrid>
			}
		</>
	);
};

export default ProductList;

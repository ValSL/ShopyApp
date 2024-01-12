'use client';

import { Box, SimpleGrid, TextInput, Text, Pagination } from "@mantine/core";
import React, { useDeferredValue, useEffect, useState } from "react";
import Filter from "./components/Filter";
import classes from "./home.module.css";
import { IconSearch } from "@tabler/icons-react";
import { useDebouncedValue, useMediaQuery } from '@mantine/hooks';
import { useGetAllProducts } from "./api/productListApi";
import { ProductCard } from "./components/ProductItem";




const ProductList = () => {
	const matches = useMediaQuery('(min-width: 55rem)');

	const [pageSize, setPageSize] = useState(6);
	const [currentPage, setCurrentPage] = useState(1);

	const [query, setQuery] = useState('');
	const [debouncedQuery] = useDebouncedValue(query, 500);

	const [fromFilter, setFromFilter] = useState<string | number>("");
	const [debouncedFromFilter] = useDebouncedValue(fromFilter, 500);

	const [toFilter, setToFilter] = useState<string | number>("");
	const [debouncedToFilter] = useDebouncedValue(toFilter, 500);


	useEffect(() => {
		if (matches) {
			setPageSize(6);
			setCurrentPage(1);
		}
		else {
			setPageSize(3);
			setCurrentPage(1);
		}
	}, [matches]);

	const { data, isLoading, isError } = useGetAllProducts(currentPage, pageSize, debouncedQuery, debouncedFromFilter as number, debouncedToFilter as number);

	if (isLoading) return <></>;

	return (
		<>
			{matches ?
				<>
					<SimpleGrid cols={4} px="3rem" spacing={25}>
						<Box className={classes.filter}>
							<Filter fromFilter={debouncedFromFilter as number} toFilter={debouncedToFilter as number} setToFilter={setToFilter} setFromFilter={setFromFilter} />
						</Box>
						<Box className={classes.searchInput}>
							<TextInput value={query} onChange={(e) => setQuery(e.target.value)} leftSection={<IconSearch size={16} />} radius="8px" placeholder="Type to search..." />
						</Box>
						<Box>
							<Text fw="bold">{data?.productsCount} Results</Text>
						</Box>
						<Box style={{ justifySelf: "end", gridColumn: "3 / span 2" }}>
							<Text>Sort by newest</Text>
						</Box>
						<Box style={{ justifySelf: "start", gridColumn: "2 / span 3" }}>
							<Text>${debouncedFromFilter === "" ? 0 : debouncedFromFilter} - ${debouncedToFilter === "" ? 0 : debouncedToFilter}</Text>
						</Box>
						{
							data?.products.map((product) => {
								return (
									<div key={product.productId}>
										<ProductCard product={product} />
									</div>
								);
							})
						}

					</SimpleGrid>
					<Box className={classes.pageBlock}>
						<Pagination total={Math.ceil(data!.productsCount / pageSize)} value={currentPage} onChange={setCurrentPage} mt="sm" />
					</Box>
				</>
				:
				<>
					<SimpleGrid cols={1} px="3rem" >
						<Box>
							<TextInput value={query} onChange={(e) => setQuery(e.target.value)} leftSection={<IconSearch size={16} />} radius="8px" placeholder="Type to search..." />
						</Box>
						<Filter fromFilter={debouncedFromFilter as number} toFilter={debouncedToFilter as number} setToFilter={setToFilter} setFromFilter={setFromFilter} />
						<Box>
							<Text fw="bold">{data?.productsCount} Results</Text>
						</Box>
						<Box>
							<Text>Sort by newest</Text>
						</Box>
						<Box >
							<Text>${debouncedFromFilter} - ${debouncedToFilter}</Text>

						</Box>
						{
							data?.products.map((product) => {
								return (
									<div key={product.productId}>
										<ProductCard product={product} />
									</div>
								);
							})
						}
					</SimpleGrid>
					<Box className={classes.pageBlock}>
						<Pagination total={Math.ceil(data!.productsCount / pageSize)} value={currentPage} onChange={setCurrentPage} mb="sm" />
					</Box>
				</>
			}
		</>
	);
};

export default ProductList;

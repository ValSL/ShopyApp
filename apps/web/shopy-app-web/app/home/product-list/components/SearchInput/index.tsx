import { Box, TextInput } from "@mantine/core";
import { IconSearch } from "@tabler/icons-react";
import React from 'react';
import classes from "./searchInput.module.css";

type SearchInputProps = {
	query: string;
	setQuery: React.Dispatch<React.SetStateAction<string>>;
}

const SearchInput = ({query, setQuery}: SearchInputProps) => {
	return (
		<Box className={classes.searchInput}>
			<TextInput value={query} onChange={(e) => setQuery(e.target.value)} leftSection={<IconSearch size={16} />} radius="8px" placeholder="Type to search..." />
		</Box>
	);
};

export default SearchInput;
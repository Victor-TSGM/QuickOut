import { FuncionarioViewModel } from '@/domain/models/FuncionarioViewModel';
import { faEdit, faIndent, faPlus, faSearch } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import * as React from 'react';
import './FuncionarioIndex.css';
import {
  EditRegular,
  DeleteRegular,
  ShareScreenPersonOverlayInside16Regular,
} from "@fluentui/react-icons";
import {
  TableBody,
  TableCell,
  TableRow,
  Table,
  TableHeader,
  TableHeaderCell,
  TableCellLayout,
  Button,
  useArrowNavigationGroup,
  useFocusableGroup,
} from "@fluentui/react-components";
import { VInput } from '@/presentation/Components/VInput/VInput';
import { useNavigate } from 'react-router-dom';

export interface Props {

}

const funcionarios: FuncionarioViewModel[] = [
  {
    id: 123456,
    nome: 'Flávio Tadeu',
    cargo: 'Vigilante 01'
  },
  {
    id: 654321,
    nome: 'Ivani Aparecida',
    cargo: 'Controle de Acesso'
  },
  {
    id: 345645,
    nome: 'Emerson dos Santos',
    cargo: 'Vigilante 01'
  },
  {
    id: 556666,
    nome: 'Ivonete Aparecida',
    cargo: 'Controle de Acesso'
  },
  {
    id: 3345554,
    nome: 'Ivani Aparecida',
    cargo: 'Controle de Acesso'
  },
  {
    id: 776555,
    nome: 'Patrick',
    cargo: 'Vigilante'
  },
  {
    id: 4545345,
    nome: 'Ivete Aparecida',
    cargo: 'Controle de Acesso'
  }

]

const columns = [
  { columnKey: "id", label: "Id" },
  { columnKey: "nome", label: "Nome" },
  { columnKey: "cargo", label: "Cargo" },
  { columnKey: "actions", label: "Ações" },
];

const FuncionarioIndex = (props: Props) => {
  const [selected, setSelected] = React.useState<FuncionarioViewModel>(null);
  const navigate = useNavigate();

  const [searchValue, setSearchValue] = React.useState<string>('')
  const [listaFuncionarios, setListaFuncionarios] = React.useState<FuncionarioViewModel[]>(funcionarios);
  const keyboardNavAttr = useArrowNavigationGroup({ axis: "grid" });
  const focusableGroupAttr = useFocusableGroup({
    tabBehavior: "limited-trap-focus",
  });

  const searchEmployees = (value: string) => {
    if (searchValue == '') {
      setListaFuncionarios(funcionarios)
    } else {
      let employees = listaFuncionarios.filter(x => x.nome.toLowerCase().includes(searchValue.toLowerCase()))
      setListaFuncionarios(employees)
    }
  }

  React.useEffect(() => {
    console.log(searchValue);
    searchEmployees(searchValue)
  }, [searchValue])

  return (
    <div className="g-0">
      <div className="col-12 p-2 crud-bar">
        <button className='btn btn-primary p-2 mx-2' onClick={() => {
          navigate('/funcionario/novo')
        }}><FontAwesomeIcon icon={faPlus} />&nbsp;Novo</button>
        <button className='btn btn-secondary p-2'><FontAwesomeIcon icon={faEdit} />&nbsp;Editar</button>
      </div>
      <div className="col-12 funcionario-content">
        <div className="col-12 filter-section px-2 py-1 d-flex flex-row">
          <VInput placeholder='Buscar' type='search' chageValue={(value: string) => { setSearchValue(value) }} />
          <button className='btn p-2'><FontAwesomeIcon icon={faSearch} /></button>
        </div>
        <Table
          {...keyboardNavAttr}
          role="grid"
          aria-label="Table with grid keyboard navigation"
        >
          <TableHeader style={{background: 'black', color: 'white'}}>
            <TableRow >
              {columns.map((column) => (
                <TableHeaderCell key={column.columnKey} style={{padding: '10px'}}>
                  {column.label}
                </TableHeaderCell>
              ))}
              <TableHeaderCell />
            </TableRow>
          </TableHeader>
          <TableBody  >
            {listaFuncionarios.map((item) => (
              <TableRow key={item.id} style={{borderBottom: '1px solid grey'}}>
                <TableCell tabIndex={0} role="gridcell" className='px-2'>
                  <TableCellLayout media={<ShareScreenPersonOverlayInside16Regular />}>
                    &nbsp;{item.id}
                  </TableCellLayout>
                </TableCell>
                <TableCell tabIndex={0} role="gridcell">
                  <TableCellLayout
                  >
                    {item.nome}
                  </TableCellLayout>
                </TableCell>
                <TableCell tabIndex={0} role="gridcell">
                  {item.cargo}
                </TableCell>
                <TableCell role="gridcell" tabIndex={0} {...focusableGroupAttr}>
                  <TableCellLayout>
                    <Button icon={<EditRegular />} aria-label="Edit" />
                    <Button icon={<DeleteRegular />} aria-label="Delete" />
                  </TableCellLayout>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}

export default FuncionarioIndex;
import { faCancel, faSave } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import * as React from 'react';


export interface Props {

}

const FuncionarioForm = (props: Props) => {
  return (
    <div className="g-0">
      <div className="col-12 action-bar">
        <button className='btn btn-primary p-2'><FontAwesomeIcon icon={faSave}/></button>
        <button className='btn btn-edit p-2'><FontAwesomeIcon icon={faCancel}/></button>
      </div>
    </div>
  );
}
 
export default FuncionarioForm;